﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abatract
{
    public interface IContentService
    {
        List<Content> GetContentList();

        void ContentAddBL(Content content);

        Content GetByID(int id);

        void ContentDeleteBL(Content content);

        void ContentUpdateBL(Content content);

        List<Content> GetListByHeadingID(int id);
    }
}