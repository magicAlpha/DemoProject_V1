using GMailUnitFramework.Commons;
using NUnitFramework.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomationTest
{
    class RestAPIHelper
    {

        static RestClient client;
        static IRestResponse response;
        static RestRequest request;
        
        // This will set the URL(base and endPoint) property for requests made by the clients instance
        public static RestClient URLSetUp(String baseURL, String endPointURL)
        {
            try
            {
                String completeURL = baseURL + endPointURL;
                client = new RestClient(completeURL);
            }
            catch (Exception e)
            {
                throw e;
            }
            return client;
        }

        // This is the container for the data used to make request
        public static RestRequest CreateGETRequest()
        {
            request = new RestRequest(Method.GET);
            try
            {
                request.AddHeader(Const.HeaderParameterAccept, Const.HeaderParameterContentType);
            }
            catch(Exception e)
            {
                throw e;
            }
            return request;
        }

        // This will execute requested method and return the content in the form of response interface object
        // // This is the container for data sent back from API
        public static IRestResponse GetResponse()
        {
            try
            {
                response=client.Execute(request);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        // This method will return a particular userInfo requested data 
        public static RestRequest CreateRequestBasisOnParameter(String enterValue)
        {
            try
            {
                request = new RestRequest(enterValue, Method.GET);
                request.AddHeader(Const.HeaderParameterAccept, Const.HeaderParameterContentType);
            }
            catch(Exception e)
            {
                throw e;
            }
            return request;
        }

        // This method will add an entity 
        public static RestRequest CreatePOSTRequest(String id, String activities)
        {
            UserInformations userInformationObj = new UserInformations();
            try
            {
                request = new RestRequest(Method.POST);
                request.AddHeader(Const.HeaderParameterAccept, Const.HeaderParameterContentType);               
                userInformationObj.Id = id;
                userInformationObj.Title = activities;
                request.AddJsonBody(userInformationObj);
            }
            catch(Exception e)
            {
                throw e;

            }
            return request;
        }

        // This method will delete an entity basis on user requirement
        public static RestRequest CreateDELETERequest(String enterValueToBeDelete)
        {
            try
            {
                request = new RestRequest(enterValueToBeDelete,Method.DELETE);
            }
            catch(Exception e)
            {
                throw e;
            }

            return request;
        }

        // This method will update or modify an existing entity basis on user requirement
        public static RestRequest CreatePUTRequest(string enterId, string photoInfoURL, string photoInfoTitle)
        {
            PhotoInformation photoInformation = new PhotoInformation();
            try
            {
                request = new RestRequest(enterId, Method.PUT);
                photoInformation.title = photoInfoTitle;
                photoInformation.url = photoInfoURL;
                request.AddJsonBody(photoInformation);
            }
            catch (Exception e)
            {
                throw e;
            }
            return request;
        }

    }
}
