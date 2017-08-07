using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol
{
    public class Assign
    {
        Entity db = new Entity();
        //1.	Поиск по ФИО, и по ИИН в базе всех существующих пациентов
        public List<TablePatient> FindPatient(string FirstName, string LastName, string MiddleName="", string IIN="")
        {
            //1.если есть действующий (не обработанный)  запрос на прикрепление пациента, который подходит под критерии поиска, то он не должен отображаться в результатах поиска.
            List<int> ReqPatients = db.TableRequests.Where(w => w.StatusId == 3).Select(s => s.PatientId).ToList();

            List< TablePatient > TP = new List<TablePatient>();
            if (!string.IsNullOrEmpty(IIN))
            {
                TP = db.TablePatients.Where(w => w.IIN == IIN && !ReqPatients.Contains(w.PatientId)).ToList();
            }
            else if (!string.IsNullOrEmpty(MiddleName))
            {
                TP =
                    db.TablePatients.Where(
                        w => w.FirstName == FirstName && w.LastName == LastName && w.MiddleName == MiddleName && !ReqPatients.Contains(w.PatientId)).ToList();
            }
            else
            {
                TP =
                    db.TablePatients.Where(
                        w => w.FirstName == FirstName && w.LastName == LastName && !ReqPatients.Contains(w.PatientId)).ToList();
            }


            return TP;
        }
        //2.	Из результатов поиск должна быть возможность, выбрать пациента и создать запрос на прикрепление, на выбранную организацию.
        public TableRequests DoAssignRequests(int patientId, int orgId, int userId)
        {
            //Если у пользователя нет прав  «Контролирующий модуль» то он может создавать запросы на прикрепление0
            //, только на ту организацию за которой он закреплен.
            TableUsers user = db.TableUsers.FirstOrDefault(w => w.UserId == userId /*.Equals(userId)*/);

            TableRequests TR = new TableRequests
            {
                CreateDate = DateTime.Now,
                PatientId = patientId,
                StatusId = 3,
                MedOraganizationsId = user.RoleId == 0 ? user.MedOraganizationsId : orgId
            };
            
            db.TableRequests.Add(TR);
            db.SaveChanges();
            return TR;
        }
    }
}
