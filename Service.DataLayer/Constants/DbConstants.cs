using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.Constants
{
   public class DbConstants
    {
        public class Params
        {
            public static readonly string PARAM_Analysis = "مرحلة التحليل";
            public static readonly string PARAM_Prototype = "مرحلة الواجهات";
            public static readonly string PARAM_SofwareArchetucure = "مرحلة البنية الهيكلية وتصميم قاعدة البيانات";
            public static readonly string PARAM_Development = "مرحلة البرمجة والتطوير";
            public static readonly string PARAM_Testing = "مرحلة الاختبار";
            public static readonly string PARAM_Execution = "مرحلة التنفيذ";
            public static readonly string PARAM_Delivery = "مرحلة التسليم";

            public static readonly string PARAM_AnalysisE = "Analysis Phase";
            public static readonly string PARAM_PrototypeE = "Prototype Phase";
            public static readonly string PARAM_SofwareArchetucureE = "Sofware Archetucure and DB Design Phase";
            public static readonly string PARAM_DevelopmentE = "Development Phase";
            public static readonly string PARAM_TestingE = "Testing Phase";
            public static readonly string PARAM_ExecutionE = "Execution Phase";
            public static readonly string PARAM_DeliveryE = "Delivery Phase";

            //Analysis
            public static readonly string PARAM_AnalysisAnalysis = "التحليل";
            public static readonly string PARAM_AnalysisReview = "المراجعة";

            public static readonly string PARAM_AnalysisAnalysisEn = "Analysis";
            public static readonly string PARAM_AnalysisReviewEn = "Review";

            //Prototype
            public static readonly string PARAM_PrototypeAr = "تصميم الواجهات";
            public static readonly string PARAM_PrototypeEn = "Screens Prototype";

            //Analysis
            public static readonly string PARAM_ArchetucureDesign = "تصميم الهيكلية وقاعدة البيانات";
            public static readonly string PARAM_ArchetucureReview = "المراجعة للهيكلية";

            public static readonly string PARAM_ArchetucureDesignEn = "Archetucure Analysis";
            public static readonly string PARAM_ArchetucureReviewEn = "Archetucure Review";

            //Development
            public static readonly string PARAM_DevelopmentFront = "تصميم وبرمجة الواجهات";
            public static readonly string PARAM_DevelopmentBack = "برمجة الكود";

            public static readonly string PARAM_DevelopmentFrontEn = "Front End Development";
            public static readonly string PARAM_DevelopmentBackEn = "Back End Development";

            //Testing
            public static readonly string PARAM_TestingDesign = "تصميم حالات الاختبار";
            public static readonly string PARAM_TestingExecution = "تنفيذ الاختبار";

            public static readonly string PARAM_TestingDesignEn = "Test Cases Design";
            public static readonly string PARAM_TestingExecutionEn = "Test Execution";

            //Execution
            public static readonly string PARAM_ExecutionAr = "التطبيق والتنفيذ";
            public static readonly string PARAM_ExecutionEn = "Implementation and Execution";

            //Delivery
            public static readonly string PARAM_DeliveryAr = "التسليم";
            public static readonly string PARAM_DeliveryEn = "Delivery";


            private List<string> SetPhasesList()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_Analysis);
                phases.Add(PARAM_Prototype);
                phases.Add(PARAM_SofwareArchetucure);
                phases.Add(PARAM_Development);
                phases.Add(PARAM_Testing);
                phases.Add(PARAM_Execution);
                phases.Add(PARAM_Delivery);

                return phases;
            }

            private List<string> SetPhasesListEnglish()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_AnalysisE);
                phases.Add(PARAM_PrototypeE);
                phases.Add(PARAM_SofwareArchetucureE);
                phases.Add(PARAM_DevelopmentE);
                phases.Add(PARAM_TestingE);
                phases.Add(PARAM_ExecutionE);
                phases.Add(PARAM_DeliveryE);

                return phases;
            }

            public List<string> getPhasesList() 
            {
               return SetPhasesList();
            }

            public List<string> getPhasesListEnglish()
            {
                return SetPhasesListEnglish();
            }

            private List<string> SetAnalysisListAr()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_AnalysisAnalysis);
                phases.Add(PARAM_AnalysisReview);
                return phases;
            }

            private List<string> SetAnalysisListEn()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_AnalysisAnalysisEn);
                phases.Add(PARAM_AnalysisReviewEn);
                
                return phases;
            }

            public List<string> getAnalysisListAr()
            {
                return SetAnalysisListAr();
            }

            public List<string> getAnalysisListEn()
            {
                return SetAnalysisListEn();
            }

            private List<string> SetArchetucureListAr()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_ArchetucureDesign);
                phases.Add(PARAM_ArchetucureReview);
                return phases;
            }

            private List<string> SetArchetucureListEn()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_ArchetucureDesignEn);
                phases.Add(PARAM_ArchetucureReviewEn);

                return phases;
            }

            public List<string> getArchetucureListAr()
            {
                return SetArchetucureListAr();
            }

            public List<string> getArchetucureListEn()
            {
                return SetArchetucureListEn();
            }

            private List<string> SetDevelopmentListAr()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_DevelopmentFront);
                phases.Add(PARAM_DevelopmentBack);
                return phases;
            }

            private List<string> SetDevelopmentListEn()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_DevelopmentFrontEn);
                phases.Add(PARAM_DevelopmentBackEn);

                return phases;
            }

            public List<string> getDevelopmentListAr()
            {
                return SetDevelopmentListAr();
            }

            public List<string> getDevelopmentListEn()
            {
                return SetDevelopmentListEn();
            }

            private List<string> SetTestingListAr()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_TestingDesign);
                phases.Add(PARAM_TestingExecution);
                return phases;
            }

            private List<string> SetTestingListEn()
            {
                List<string> phases = new List<string>();

                phases.Add(PARAM_TestingDesignEn);
                phases.Add(PARAM_TestingExecutionEn);

                return phases;
            }

            public List<string> getTestingListAr()
            {
                return SetTestingListAr();
            }

            public List<string> getTestingListEn()
            {
                return SetTestingListEn();
            }
        }
    }
}
