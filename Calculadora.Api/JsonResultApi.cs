using System;

namespace Calculadora.Api
{
    public class JsonResultApi
    {
        public JsonResultApi()
        {
            this.Success = false;
            this.Message = "";
            this.Data = null;
        }
        

        public JsonResultApi(Exception ex)
        {
            this.Success = false;
            this.Message = ex.Message;
            this.Data = null;
        }
        public bool Success { get; set; }
        public Object Data { get; set; }
        public string Message { get; set; }
    }
   

}
