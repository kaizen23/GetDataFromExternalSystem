using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdataWebSerwis.Models
{
	public class ClientApp
	{
        public bool Active { get; set; }

      
        public string AllowedOrigin { get; set; }


        public string Id { get; set; }

        
        public string Name { get; set; }

        public int RefreshTokenLifeTime { get; set; }

       
        public string Secret { get; set; }
    }
}