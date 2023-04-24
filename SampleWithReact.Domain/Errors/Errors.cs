using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace SampleWithReact.Domain.Errors
{
    public static class Errors
    {
        public static Error NotFound = Error.NotFound(
            "Common.NotFound",
            "Kayıt bulunamamıştır.");

        public static Error DbPersistence = Error.Failure(
            "Common.DbPersistence",
            "Kayıt işlemi sırasında hata oluştu.");
    }
}
