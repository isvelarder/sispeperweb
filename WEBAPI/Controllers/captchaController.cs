using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class captchaController : ApiController
    {
        private string GetCaptchaString(int length)
        {
            int intZero = '0';
            const int intNine = '9';
            const int intA = 'A';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strCaptchaString = "";
            var random = new Random(DateTime.Now.Millisecond);
            while (intCount < length)
            {
                intRandomNumber = random.Next(intZero, intZ);
                if (((intRandomNumber >= intZero) && (intRandomNumber <= intNine) || (intRandomNumber >= intA) && (intRandomNumber <= intZ)))
                {
                    strCaptchaString = strCaptchaString + (char)intRandomNumber;
                    intCount = intCount + 1;
                }
            }
            return strCaptchaString;
        }

        [HttpPost]
        [Route("xDrp87Hytgvrdsssf43f")]
        public byte[] GetCaptcha()
        {
            var bmp = new Bitmap(150, 30);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(234, 68, 68));
            var randomString = GetCaptchaString(6);
            HttpContext.Current.Session["captchastring"] = randomString;
            g.DrawString(randomString, new Font("Courier", 16), new SolidBrush(Color.WhiteSmoke), 2, 2);
            byte[] byteArray = new byte[0];
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Png);
                stream.Close();
                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        [HttpPost]
        [Route("hfgRfsgsVbfdsgs98")]
        public string GetValidCaptcha([FromBody] string captchaText)
        {
            var captchastring = (string)HttpContext.Current.Session["captchastring"];
            var _ok = (string.Equals(captchaText, captchastring)) ? "1" : "0";
            return (_ok);
        }
    }
}
