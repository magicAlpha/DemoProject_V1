using System;
using System.Net;
using NUnit.Framework;
using NUnitFramework.Utils;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpAPIAutomationTest;
using Assert = NUnit.Framework.Assert;

namespace NUnitFramework.Tests
{

    public class RestSharpAPITest : TestBase
    {
        public RestSharpAPITest() : base()
        {

        }

        RestAPIHelper restAPIHelper;
                
        [Test]
        public void VerifyGetRequest()
        {
            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("GetRequestEndpoint");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateGETRequest();
                IRestResponse response = RestAPIHelper.GetResponse();
                String responseFromGetRequest = response.Content;                
                Console.WriteLine(responseFromGetRequest);               
                HttpStatusCode statusCode = response.StatusCode;
                int responseStatusCode = (int)statusCode;
                string responseStatus = statusCode.ToString();
                Assert.AreEqual(responseStatusCode, Const.HTTP_RESPONSE_CODE_200, LogMessage.IncorrectResponseStatusCode);
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, LogMessage.IncorrectResponseStatus);
                Console.WriteLine("Response code is : " + responseStatusCode);
                Console.WriteLine("The status of response is : " + responseStatus);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.GETAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }        

        [Test]
        public void VerifyPostRequest()
        {
            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("PostRequestEndpoint");
            string enterIdNumber = TestData.GetData("PostRequestID");
            string activitiesNumber = TestData.GetData("PostRequestActivitiesNumber");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePOSTRequest(enterIdNumber, activitiesNumber);
                IRestResponse response = RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo = response.Content;
                Console.WriteLine(singleUserActivitiesInfo);

                HttpStatusCode httpStatusCode = response.StatusCode;
                int responseCode = (int)httpStatusCode;
                string responseStatus = response.StatusCode.ToString();

                Console.WriteLine("Response code is : " + responseCode + " after adding an entity ( Details : " + enterIdNumber + " " + activitiesNumber +")");
                Console.WriteLine("The status of response is : " + responseStatus + " after adding an entity ( Details : " + enterIdNumber + " " + activitiesNumber + ")");

                Assert.AreEqual(responseCode, Const.HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.POSTAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }


        [Test]
        public void VerifyDeleteRequest()
        {

            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("DeleteRequestEndpoint");
            string userIdNumber = TestData.GetData("DeleteRequestID");
            string enterValue = Const.Backslash + userIdNumber;
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateDELETERequest(enterValue);
                IRestResponse response = RestAPIHelper.GetResponse();
                String responseFromGetRequest = response.Content;
                Console.WriteLine(responseFromGetRequest);
                HttpStatusCode statusCode = response.StatusCode;
                int statusCodeOfResponseIs=(int)statusCode;
                String StatusOfResponseIs = statusCode.ToString();
                Console.WriteLine("Response code is : " + statusCodeOfResponseIs + " after deletion of an entity --> " + userIdNumber);
                Console.WriteLine("The status of response is : " + StatusOfResponseIs + " after deletion of an entity --> "+ userIdNumber);

                Assert.AreEqual(statusCodeOfResponseIs, Const.HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(StatusOfResponseIs, Const.HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");

            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.DELETEAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        [Test]
        public void VerifyPutRequest()
        {
            string baseURL = TestData.GetData("PUTRequestURL");
            string endPointURL = TestData.GetData("PUTRequestEndpoint");
            string enterId = TestData.GetData("PutRequestID");
            string photoInfoURL = TestData.GetData("PutPhotoInfoURL");
            string photoInfoTitle = TestData.GetData("PutPhotoInfoTitle");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePUTRequest(enterId, photoInfoURL, photoInfoTitle);
                IRestResponse response = RestAPIHelper.GetResponse();
                // This will get content of executed requested method 
                String responseFromAPI = response.Content;
                Console.WriteLine(responseFromAPI);
                HttpStatusCode statusCode = response.StatusCode;
                int statusCodeOfResponseIs = (int)statusCode;
                String StatusOfResponseIs = statusCode.ToString();
                Console.WriteLine("Response code is : " + statusCodeOfResponseIs + " after updating of an entity --> " + enterId);
                Console.WriteLine("The status of response is : " + StatusOfResponseIs + " after updating of an entity --> " + enterId);

                if (!responseFromAPI.Contains(Const.PutAPIResponse))
                {
                    Assert.Fail("Photos page details is not displayed");
                }

                Assert.AreEqual(statusCodeOfResponseIs, Const.HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(StatusOfResponseIs, Const.HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");

            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.PUTAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}
