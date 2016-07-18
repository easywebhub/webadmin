﻿using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Configuration.Client;

namespace admincenter.App_Start
{
    public static class CouchbaseConfig
    {
        public static void Initialize()
        {
            var config = new ClientConfiguration();
            config.BucketConfigs.Clear();

            config.Servers = new List<Uri>(new Uri[] { new Uri(CouchbaseConfigHelper.Instance.Server) });

            config.BucketConfigs.Add(
                CouchbaseConfigHelper.Instance.Bucket,
                new BucketConfiguration
                {
                    BucketName = CouchbaseConfigHelper.Instance.Bucket,
                    Username = CouchbaseConfigHelper.Instance.User,
                    Password = CouchbaseConfigHelper.Instance.Password
                });

            config.BucketConfigs.Add(
                "default",
                new BucketConfiguration
                {
                    BucketName = "default",
                    Username = CouchbaseConfigHelper.Instance.User,
                    Password = CouchbaseConfigHelper.Instance.Password
                });

            ClusterHelper.Initialize(config);
        }

        public static void Close()
        {
            ClusterHelper.Close();
        }
    }
}