using ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Model;

namespace ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Service
{
    public interface IService
    {
        public List<D3STD> allstd();
        public D3STD GetById(int id);
        public string InsertStd(D3STD std);
        public string UpdateStd(D3STD std);
        public string DeleteStd(int id);
    }
}
