﻿
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadControl
{
    public interface UuploadInterface
    {
        void uploadfilemultiple(IList<IFormFile> files);
    }
}
