using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public class Error
    {
        public Error()
        {
        }

        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        public string Description { get; set; }
    }
}
