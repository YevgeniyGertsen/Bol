using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol
{
    public class Control:Entity
    {
        //1.Отобразить все запросы на прикрепление
        public List<TableRequests> GetAllRequestses()
        {
            return TableRequests.Where(w => w.StatusId == 3).ToList();
        }

        //2.Одобрение либо отклонение выбранного запроса на прикрепление 
        //(после обработки автоматически проставляется дата обработки в выбранном запросе)
        public bool DoAssiginApprove(int RequestId)
        {
            TableRequests TR = TableRequests.FirstOrDefault(w => w.ReauestId == RequestId);
            TR.StatusId = 1;
            TR.FinishTime = DateTime.Now;

            TablePatient Patient = TablePatients.FirstOrDefault(w => w.PatientId == TR.PatientId);
            Patient.MedOraganizationsId = TR.MedOraganizationsId;

            SaveChanges();

            return true;

        }
    }
}
