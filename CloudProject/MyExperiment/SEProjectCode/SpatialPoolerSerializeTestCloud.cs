using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoCortexApi;
using NeoCortexApi.Entities;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using NeoCortexApi.Utility;
using NeoCortex;
using Newtonsoft.Json;

using Newtonsoft.Json.Serialization;

namespace MyExperiment.SEProjectCode
{
    [TestClass]
    /// <summary>
    /// This file contains multiple Unit Test that implements and demonstrates newly integrated Serialization Functionality of Spatial Pooler
    /// </summary>
    public class SpatialPoolerSerializeTestCloud
    {
        //Below Inputs can be used Globally for all the test cases
        //  int[] activeArray = new int[32 * 32];
        /*   int[] inputVector =  {
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                          1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                          1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,
                                          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                          1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0 }; */




        //Setting up Default Parameters for the Spatial Pooler Test cases
        private static Parameters GetDefaultParams()
        {
            ThreadSafeRandom rnd = new ThreadSafeRandom(42);

            var parameters = Parameters.getAllDefaultParameters();
            parameters.Set(KEY.POTENTIAL_RADIUS, 10);
            parameters.Set(KEY.POTENTIAL_PCT, 0.75);
            parameters.Set(KEY.GLOBAL_INHIBITION, false);
            parameters.Set(KEY.LOCAL_AREA_DENSITY, -1.0);
            parameters.Set(KEY.NUM_ACTIVE_COLUMNS_PER_INH_AREA, 80.0);
            parameters.Set(KEY.STIMULUS_THRESHOLD, 0);
            parameters.Set(KEY.SYN_PERM_INACTIVE_DEC, 0.01);
            parameters.Set(KEY.SYN_PERM_ACTIVE_INC, 0.1);
            parameters.Set(KEY.SYN_PERM_CONNECTED, 0.1);
            parameters.Set(KEY.MIN_PCT_OVERLAP_DUTY_CYCLES, 0.001);
            parameters.Set(KEY.MIN_PCT_ACTIVE_DUTY_CYCLES, 0.001);
            parameters.Set(KEY.WRAP_AROUND, true);
            parameters.Set(KEY.DUTY_CYCLE_PERIOD, 10);
            parameters.Set(KEY.MAX_BOOST, 1.0);
            parameters.Set(KEY.RANDOM, rnd);
            parameters.Set(KEY.IS_BUMPUP_WEAKCOLUMNS_DISABLED, true);


            return parameters;
        }


        

        /// <summary>
        /// Thie following Test Class runs SpatialPooler 32x32 with input of 16x16 . It learns the sequence to stable SDR representation.
        /// in very few steps. Test runs 5 iterations and keeps stable SDR encoded sequence.
        /// After 5 steps, current instance of learned SpatialPooler (SP1) is serialized to JSON and the Serialized Properties are returned in a string.
        /// The output of this method which are the Serialized properties are used for subsequent uploading to Cloud Storage.
       
        /// </summary>
        [TestMethod]
        [TestCategory("LongRunning")]


        public string SerializationTestWithTrainedData(int[] inputVector)
        {
            var parameters = GetDefaultParams();

            parameters.setInputDimensions(new int[] { 16 * 16 });
            parameters.setColumnDimensions(new int[] { 32 * 32 });
            parameters.setNumActiveColumnsPerInhArea(0.02 * 32 * 32);
            parameters.setMinPctOverlapDutyCycles(0.01);

            var mem = new Connections();
            parameters.apply(mem);

            var sp1 = new SpatialPooler();
            sp1.init(mem);


            int[] activeArray = new int[32 * 32];

           // int[] inputVector = Helpers.GetRandomVector(16 * 16, parameters.Get<Random>(KEY.RANDOM));
           /*   int [] inputVector =  {
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                             1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,
                                             1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,
                                             1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                                             0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                             0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                             1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0 };
           */
          
            string str1 = String.Empty;

            for (int i = 0; i < 5; i++)
            {
                sp1.compute(inputVector, activeArray, true);

                var activeCols1 = ArrayUtils.IndexWhere(activeArray, (el) => el == 1);

                str1 = Helpers.StringifyVector(activeCols1);

                Debug.WriteLine(str1);
            }



            sp1.Serializer("spTrain1.json");

            string ser1 = File.ReadAllText("spTrain1.json");
            return ser1;
            

        }
        /// <summary>
        /// The following test class received Serialized output in the form of a file or string (in this case downloaded from the cloud storage) and then deserializes the same to a Spatial Pooler object.
        /// </summary>
        public SpatialPooler SpatialPoolerCloudDeserializerTest(string filename)
        {
            var sp2 = SpatialPooler.Deserializer(filename);
            return sp2;
            
        } 



    }

}