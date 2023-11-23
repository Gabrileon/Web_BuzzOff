using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Others
{
    public class MyEnuns
    {
        public enum Access
        {
            Administrator = 1,
            Agent = 2,
            Common = 3
        }
        public enum Priority
        {
            Alta = 1,
            Média = 2,
            Baixa = 3
        }

        public enum FocusType
        {
            Ovos = 1,
            Larvas = 2,
            Adultos = 3
        }

        public enum DenunciationStage
        {
            Pending = 0,
            InProgress = 1,
            Completed = 2
        }
    }
}
