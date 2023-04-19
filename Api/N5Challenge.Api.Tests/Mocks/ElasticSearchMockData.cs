using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1.TestApi.MockData
{
    public class ElasticSearchMockData
    {
        public static object GetSearchResponse()
        {
            return new
            {
                took = 1,
                timed_out = false,
                _shards = new
                {
                    total = 2,
                    successful = 2,
                    failed = 0
                },
                hits = new
                {
                    total = new { value = 5 },
                    max_score = 1.0,
                    hits = Enumerable.Range(1, 5).Select(i => (object)new
                    {
                        _index = "permissions",
                        _type = "_doc",
                        _id = $"{i}",
                        _score = 1.0,
                        _source = new
                        {
                            id = i,
                            employeeName = "Maicol",
                            employeeLastName = "Jordan",
                            permissionTypeId = i + 1,
                            permissionDate = DateTime.Now,
                            permissionType = new
                            {
                                id = i + 1,
                                description = "Read",
                            }
                        }
                    }).ToArray()
                }
            };
        }
    }
}
