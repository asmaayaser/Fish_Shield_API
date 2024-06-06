﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    [Index(nameof(FishDisease.Name))]
    public class FishDisease
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(100)]
        public string? PhotoPath { get; set; }
        
        public string Description { get; set; }
        public ICollection<RecommandationActions> RecommandationActions { get; set; }
        public ICollection<CausativeAgents> CausativeAgents { get; set; }
        public ICollection<ClinicalSigns>  ClinicalSigns { get; set; }
        public ICollection<Diagnosis> Diagnosis { get; set; }
        public ICollection<Treatment> Treatment { get; set; }
        public ICollection<PreventionAndControll> PreventionAndControlls { get; set; }
        public ICollection<ImpactOnAquaculture> ImpactOnAquacultures { get; set; }
    }
  
    public class RecommandationActions
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public  int  DiseaseID { get; set; }
        public string Action { get; set; }
        public FishDisease FishDisease { get; set;}
    }

    public class CausativeAgents
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        public string? Agents { get; set; }
        public FishDisease FishDisease { get; set; }
    }
    public class ClinicalSigns
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        public string? Sign { get; set; }
        public FishDisease FishDisease { get; set; }
    }
    public class Diagnosis
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        public string Diagones { get; set; }
        public FishDisease FishDisease { get; set; }
    }
    public class Treatment
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        public string TreatmentDesc { get; set; }
        public FishDisease FishDisease { get; set; }
    }
    public class PreventionAndControll
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        
        public string Prevention { get; set; }
        public FishDisease FishDisease { get; set; }
    }

    public class ImpactOnAquaculture
    {
        public int ID { get; set; }
        [ForeignKey("FishDisease")]
        public int DiseaseID { get; set; }
        public string ImpactOnAquaculturee { get; set; }
        public FishDisease FishDisease { get; set; }

    }


}
