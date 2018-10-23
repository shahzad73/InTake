using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;


public partial class testing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            String s = Server.MapPath("~/");

            s = s + "fil.txt";

            IAmazonS3 client;
            client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = "ltimsbackups",
                Key = "AKIAJFWZRGO5DXFD6FWQ",
                FilePath = s
            };
            PutObjectResponse response2 = client.PutObject(request);

            Response.Write(s);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

            Response.Write("written");
    }

}