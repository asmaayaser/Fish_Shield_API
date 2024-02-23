using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class FishDisease
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        
        [StringLength(100)]
        public string? PhotoPath { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        //public string RecomAction { get; set; }
        public ICollection<RecommandationActions> RecommandationActions { get; set; }
       // public string CausativeAgents { get; set; }
       public ICollection<CausativeAgents> CausativeAgents { get; set; }
        //  public string ClinicalSigns { get; set; }
        public ICollection<ClinicalSigns>  ClinicalSigns { get; set; }
       // public string Diagnosis { get; set; }
        public ICollection<Diagnosis> Diagnosis { get; set; }
       // public string Treatment { get; set; }

        public ICollection<Treatment> Treatment { get; set; }
        // public string PreventionAndControll { get; set; }
        public ICollection<PreventionAndControll> PreventionAndControlls { get; set; }
        //public string ImpactOnAquaculture { get; set; }
        public ICollection<ImpactOnAquaculture> ImpactOnAquacultures { get; set; }

    }
  
    public class RecommandationActions
    {
        [ForeignKey("FishDisease")]
        public  int  DiseaseID { get; set; }

        public string Action { get; set; }

        public FishDisease FishDisease { get; set;}


      //  public override string ToString() => Action;
       
    }

    public class CausativeAgents
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string? Agents { get; set; }

        public FishDisease FishDisease { get; set; }

        //public override string ToString() => Agents;
        
    }
    public class ClinicalSigns
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string? Sign { get; set; }

        public FishDisease FishDisease { get; set; }

      //  public override string ToString() => Sign;
       
    }
    public class Diagnosis
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string Diagones { get; set; }

        public FishDisease FishDisease { get; set; }

      //  public override string ToString() => Diagones;
      
    }
    public class Treatment
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string TreatmentDesc { get; set; }

        public FishDisease FishDisease { get; set; }

      //  public override string ToString() => TreatmentDesc;
      
    }
    public class PreventionAndControll
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string Prevention { get; set; }

        public FishDisease FishDisease { get; set; }

       // public override string ToString() => Prevention;
       
    }

    public class ImpactOnAquaculture
    {
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }

        public string ImpactOnAquaculturee { get; set; }

        public FishDisease FishDisease { get; set; }

      //  public override string ToString()=> ImpactOnAquaculturee;
    }


}
