using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configrations
{
	public class FishDiseaseSeedData : IEntityTypeConfiguration<FishDisease>
	{
		public void Configure(EntityTypeBuilder<FishDisease> builder)
		{
			builder.HasData(
				new FishDisease()
				{
					ID=1,
					Name = "Streptococcosis Disease",
					PhotoPath="https://localhost:7289/images/Detects/1.jpg",
					Type = "Bacterial Disease",
					Description = "Streptococcosis is a systemic bacterial infection affecting tilapia, primarily caused by Streptococcus iniae. It poses a significant threat to tilapia aquaculture globally, leading to morbidity and mortality in affected populations.",
				},
				new FishDisease()
				{
					ID = 2,
					Name = "EUS Disease",
					PhotoPath = "https://localhost:7289/images/Detects/2.jpg",
					Type = "Fungal disease",
					Description = "Epizootic Ulcerative Syndrome (EUS) is a devastating infectious disease that primarily affects freshwater and estuarine fish species. It is caused by the fungus Aphanomyces invadans. EUS is characterized by the development of ulcerative lesions on the skin and fins of affected fish, which can lead to tissue necrosis and systemic infection. The disease is often associated with warm water temperatures and environmental stressors. EUS outbreaks can result in high mortality rates, significant economic losses for aquaculture operations, and ecological impacts on wild fish populations.",
				},
				new FishDisease()
				{
					ID = 3,
					Name = "Columnaris Disease",
					PhotoPath = "https://localhost:7289/images/Detects/3.jpg",
					Type = "Bacterial Disease",
					Description = "Columnaris disease, also known as cotton wool disease or saddleback disease, is a common bacterial infection affecting tilapia. It is caused by the bacterium Flavobacterium columnare. Columnaris disease typically presents as a systemic infection, primarily affecting the skin and gills of tilapia, although it can also impact other organs.",
				},
				new FishDisease()
				{
					ID = 4,
					Name = "Gill Disease",
					PhotoPath = "https://localhost:7289/images/Detects/4.jpg",
					Type = "bacterial, viral, or parasitic Disease",
					Description = "(BGD) is a common external infection of hatchery reared salmonids and occasionally of warm water species reared under intensive conditions. As defined by Wood (1974), the name of the disease describes the clinical signs of bacterial infections on the gills. The etiological agent of the disease is considered to be one or more species of filamentous bacteria including Flavobacterium sp. as most recently described by Wakabayashi et al. (1980). BGD is characterized by the presence of large numbers of filamentous bacteria on the gills accompanied by fusing and clubbing of the gill filaments. Acute or chronic forms of the disease may occur and acute outbreaks may involve daily mortality rates approaching 20% (Warren 1981). The onset of bacterial gill disease usually follows a deterioration of environmental conditions associated with overcrowding and increases in toxic metabolic waste products. According to Wood (1979), fish smaller than 90-100/lb are most susceptible to the disease. Successful treatment can only be accomplished through prompt therapy and alleviation of poor environmental conditions.",
				}
			);
		}
	}

	public class PrventionAndControllSeeds : IEntityTypeConfiguration<PreventionAndControll>
	{
		public void Configure(EntityTypeBuilder<PreventionAndControll> builder)
		{
			builder.HasData(
			#region First
						new PreventionAndControll
						{
							ID = 1,
							DiseaseID = 1,
							Prevention = "Quarantine protocols for new fish introductions."
						},
						new PreventionAndControll
						{
							ID = 2,
							DiseaseID = 1,
							Prevention = "Disinfection of equipment and facilities."
						},
						new PreventionAndControll
						{ID = 3,
							DiseaseID = 1,
							Prevention = "Minimization of stressors through proper husbandry practices"
						},
						new PreventionAndControll
						{ID = 4,
							DiseaseID = 1,
							Prevention = "Implementation of vaccination programs where feasible."
						},
						new PreventionAndControll
						{ID = 5,
							DiseaseID = 1,
							Prevention = "Surveillance and early intervention in case of disease outbreaks."
						}

						#endregion
				,
			#region Second
						new PreventionAndControll
						{
							ID = 6,
							DiseaseID = 2,
							Prevention = "Isolation and Screening: Quarantine new fish and screen them for disease."
						},
						new PreventionAndControll
						{
							ID = 7,
							DiseaseID = 2,
							Prevention = "Biosecurity: Tighten facility access and disinfect regularly."
						},
						new PreventionAndControll
						{
							ID = 8,
							DiseaseID = 2,
							Prevention = "Water Quality: Maintain optimal conditions to reduce stress."
						},
						new PreventionAndControll
						{
							ID = 9,
							DiseaseID = 2,
							Prevention = "Stocking and Care: Avoid overcrowding and ensure proper care."
						},
						new PreventionAndControll
						{
							ID = 10,
							DiseaseID = 2,
							Prevention = "Environment: Manage water quality and sediment effectively."
						},
						new PreventionAndControll
						{
							ID = 11,
							DiseaseID = 2,
							Prevention = "Monitoring: Regularly check for pathogens to catch outbreaks early."
						},
						new PreventionAndControll
						{
							ID = 12,
							DiseaseID = 2,
							Prevention = "Vaccination: Support vaccine development for long-term protection."
						},
						new PreventionAndControll
						{
							ID = 13,
							DiseaseID = 2,
							Prevention = "Regulations: Enforce rules to maintain responsible aquaculture practices."
						}
						#endregion
				,

			#region Third
				new PreventionAndControll
				{
					ID = 14,
					DiseaseID = 3,
					Prevention = "Antibiotic Therapy: Administer antibiotics such as florfenicol or oxytetracycline under veterinary supervision."
				},
						new PreventionAndControll
						{
							ID = 15,
							DiseaseID = 3,
							Prevention = "Topical Treatments: Apply topical treatments or baths with antimicrobial agents to affected fish, targeting the infection directly."
						},
						new PreventionAndControll
						{
							ID = 16,
							DiseaseID = 3,
							Prevention = "Supportive Care: Provide supportive care, including maintaining optimal water quality and nutrition, to enhance the fish's immune response and aid in recovery."
						},
						new PreventionAndControll
						{
							ID = 17,
							DiseaseID = 3,
							Prevention = "Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population."
						},
						new PreventionAndControll
						{
							ID = 18,
							DiseaseID = 3,
							Prevention = "Implement early intervention and treatment protocols in case of disease outbreaks."
						}
						#endregion
					,

			#region Forth
						new PreventionAndControll
						{
							ID = 19,
							DiseaseID = 4,
							Prevention = "The best way to prevent bacterial gill disease from occurring is by maintaining hygienic living conditions for your fish."
						},
						new PreventionAndControll()
						{
							ID = 20,
							DiseaseID = 4,
							Prevention = "Keeping the water clean of organic debris, giving the fish plenty of space in which to move, with no overcrowding"
						},
						new PreventionAndControll()
						{
							ID = 21,
							DiseaseID = 4,
							Prevention = "maintaining a consistent temperature"
						},
						new PreventionAndControll()
						{
							ID = 22,
							DiseaseID = 4,
							Prevention = "testing the water quality regularly to ensure that it is balanced are all the best practices for keeping your fish healthy and stress free"
						},
						new PreventionAndControll()
					    {
							ID = 23,
								DiseaseID = 4,
								Prevention= "Additionally, filters should be changed every month or checked according to the filter manufacturer's directions."
						}

							#endregion


			) ;
		}
	}
	public class RecommandationActionsSeeds : IEntityTypeConfiguration<RecommandationActions>
	{
		public void Configure(EntityTypeBuilder<RecommandationActions> builder)
		{

			builder.HasData(
			#region Firest 
						new RecommandationActions
						{
							ID = 1,
							DiseaseID = 1,
							Action = "Biosecurity Measures: Implement strict biosecurity protocols to prevent the introduction and spread of the bacteria."
						},
						new RecommandationActions
						{
							ID = 2,
							DiseaseID = 1,
							Action = "Water Quality Management: Maintain optimal water quality parameters to reduce stress on tilapia and support their immune function."
						},
						new RecommandationActions
						{
							ID = 3,
							DiseaseID = 1,
							Action = "Regular Health Monitoring: Conduct routine health assessments to detect early signs of infection and initiate timely interventions."
						},
						new RecommandationActions
						{
							ID = 4,
							DiseaseID = 1,
							Action = "Vaccination: Utilize available and effective vaccines to confer immunity against Streptococcus iniae."
						},
						new RecommandationActions
						{
							ID = 5,
							DiseaseID = 1,
							Action = "Prompt Treatment: Diagnose and treat infected fish promptly with appropriate antibiotics under veterinary supervision."
						} 
	#endregion
,
			#region Second
						new RecommandationActions
						{
							ID = 6,
							DiseaseID = 2,
							Action="Early Detection: Regular monitoring for signs of EUS, such as ulcerative lesions on the skin and fins, is crucial for early detection and intervention."
						},
						new RecommandationActions
						{
							ID = 7,
							DiseaseID= 2,
							Action="Quarantine Measures: Implement quarantine protocols for new fish arrivals to prevent the introduction and spread of EUS to existing populations."
						},
						new RecommandationActions
						{
							ID = 8,
							DiseaseID= 2,
							Action="Biosecurity Protocols: Maintain strict biosecurity measures to minimize the risk of EUS transmission between aquaculture facilities and wild fish populations."
						},
						new RecommandationActions {
							ID = 9,
							DiseaseID= 2,
							Action="Environmental Management: Optimize water quality parameters and minimize environmental stressors to reduce the susceptibility of fish to EUS infection."
						},
						new RecommandationActions
						{
							ID = 10,
							DiseaseID= 2,
							Action="Treatment: Investigate and implement appropriate treatment options, such as antifungal medications, under the guidance of a veterinarian or aquatic health professional."
						},
						new RecommandationActions
						{
							ID = 11,
							DiseaseID= 2,
							Action="Sanitation: Ensure proper hygiene practices, including disinfection of equipment and facilities, to prevent the buildup and spread of EUS-causing pathogens."
						},
						new RecommandationActions
						{
							ID = 12,
							DiseaseID= 2,
							Action="Research and Monitoring: Support ongoing research efforts to better understand the epidemiology and pathogenesis of EUS, and collaborate with relevant agencies for surveillance and monitoring of EUS outbreaks."
						}
					
			#endregion
						,
			#region Third

						new RecommandationActions
						{
							ID= 13,
							DiseaseID = 3,
							Action="Water Quality Management: Maintain optimal water quality parameters to reduce stress on tilapia and minimize the risk of infection."
						},
						new RecommandationActions
						{
							ID= 14,
							DiseaseID= 3,
							Action="Biosecurity Measures: Implement strict biosecurity protocols to prevent the introduction and spread of F. columnare in aquaculture systems."
						},
						new RecommandationActions
						{
							ID= 15,
							DiseaseID=3,
							Action="Regular Monitoring: Conduct routine health assessments and monitor fish behavior closely to detect early signs of infection."
						},
						new RecommandationActions {
							ID= 16,
							DiseaseID=3,
							Action="Treatment: Administer antimicrobial treatments under veterinary supervision if infections occur."
						},
						new RecommandationActions
						{
							ID= 17,
							DiseaseID= 3,
							Action="Stress Reduction: Minimize stressors such as overcrowding, poor nutrition, and environmental fluctuations to enhance tilapia immune function."
						}
				
			#endregion
						,
			#region forth

						new RecommandationActions
						{
							ID= 18,
							DiseaseID = 4,
							Action="Isolation: Separate affected fish from the main population to prevent disease spread."
						},
						new RecommandationActions
						{
							ID= 19,
							DiseaseID = 4,
							Action="Water Quality: Maintain optimal water conditions with regular monitoring and adjustments."
						},
						new RecommandationActions
						{
							ID= 20,
							DiseaseID= 4,
							Action="Treatment: Administer antibiotics or other medications as directed by a veterinarian."
						},
						new RecommandationActions {
							ID = 21,
							DiseaseID= 4,
							Action="Stress Reduction: Minimize stressors such as overcrowding and poor water quality."
						},
						new RecommandationActions
						{
							ID= 22,
							DiseaseID= 4,
							Action="Quarantine: Quarantine new arrivals to prevent introducing pathogens."
						},
						new RecommandationActions
						{
							ID= 23,
							DiseaseID= 4,
							Action="Biosecurity: Implement disinfection and hygiene practices to prevent disease transmission."
						},
						new RecommandationActions
						{
							ID= 24,
								DiseaseID= 4,
							Action="Monitoring: Monitor fish closely for changes in behavior and gill condition."
						},
						new RecommandationActions
						{
							ID= 25,
							DiseaseID= 4,
							Action="Consultation: Seek advice from experts for diagnosis and treatment guidance."
						},
						new RecommandationActions
						{
							ID= 26,
								DiseaseID= 4,
							Action="Prevention: Take preventive measures to avoid future outbreaks."
						}
					
			#endregion
			);			
					
		}
	}
	public class CausativeAgentsSeeds : IEntityTypeConfiguration<CausativeAgents>
	{
		public void Configure(EntityTypeBuilder<CausativeAgents> builder)
		{
			builder.HasData(
			#region First
				
						new CausativeAgents
						{ID=1,
							DiseaseID= 1,
							Agents="Identification: Streptococcus iniae is isolated and identified as the primary pathogen causing streptococcosis in tilapia."
						},
						new CausativeAgents
						{
							ID = 2,
							DiseaseID =1,
							Agents="Characterization: Its morphological, biochemical, and molecular properties are examined to confirm its identity."
						},
						new CausativeAgents {
							ID = 3,
							DiseaseID= 1,
							Agents="Virulence Factors: S. iniae possesses adhesion proteins, enzymes, and toxins that contribute to its ability to infect and cause disease in tilapia."
						},
						new CausativeAgents
						{ID = 4,
							DiseaseID= 1,
							Agents="Host-Pathogen Interaction: The bacterium infects tilapia through breaches in the skin or mucosal surfaces, colonizing tissues and evading immune defenses."
						},
						new CausativeAgents
						{ID = 5,

							DiseaseID= 1,
							Agents="Disease Manifestation: Infection leads to streptococcosis, resulting in systemic dissemination and clinical signs in affected tilapia."
						}

					
			#endregion
						,
			#region Second

						new CausativeAgents
						{
							ID = 6,
							DiseaseID = 2,
							Agents="EUS is caused by Aphanomyces invadans , a fungus belonging to Saprolegniales, Oomycetida, and is classified in Stramenopiles or Chromista along with diatoms and brown algae. Disinfection of infected fish pond by hydrated lime and addition of salt to inhibit the fungus has been used in EUS outbreaks"
						}
					
			#endregion
						,
			#region Third

						new CausativeAgents
						{
							ID = 7,
							DiseaseID = 3,
							Agents="Bacterial Pathogen: Flavobacterium columnare is the causative agent of Columnaris disease in tilapia."
						},
						new CausativeAgents
						{ID=8,
							DiseaseID=3,
							Agents="Gram-Negative Bacterium: It is a Gram-negative bacterium commonly found in freshwater environments."
						},
						new CausativeAgents {
							ID=9,
							DiseaseID= 3,
							Agents="Characteristic Appearance: F. columnare forms slimy colonies resembling columns, hence the name \"Columnaris.\""
						},
						new CausativeAgents
						{
							ID=10,
							DiseaseID= 3,
							Agents="Skin and Gill Affliction: It primarily affects the skin and gills of tilapia, causing white or grayish patches resembling cotton wool."
						}
				
			#endregion
						,
			#region Forth

						new CausativeAgents
						{
							ID=11,
							DiseaseID=4,
							Agents="Bacterial gill disease typically occurs as a result of poor living conditions, such as overcrowding, poor water quality, high organic debris, increased temperature of the water, and increased ammonia levels. While it is most often the young and/or weak fish that contract the disease, due to their vulnerable immune systems, gill disease can affect fish of any age."
						},
						new CausativeAgents
						{
							ID=12,
							DiseaseID = 4,
							Agents="The bacteria that cause gill infections are primarily Flavobacteria, Aeromonas and Pseudomonas spp. The direct initiating cause by these bacteria is not conclusive, but they will often be found as secondary, opportunistic infections."
						}
					
			#endregion
				);
		}
	}
	public class ClinicalSignsSeeds : IEntityTypeConfiguration<ClinicalSigns>
	{
		public void Configure(EntityTypeBuilder<ClinicalSigns> builder)
		{
			builder.HasData(
			#region First
				
						new ClinicalSigns
						{
							ID = 1,
							DiseaseID= 1,
							Sign="Lethargy and reduced activity levels."
						},
						new ClinicalSigns
						{
							ID = 2,
							DiseaseID= 1,
							Sign="Loss of appetite and reduced feeding behavior."
						},
						new ClinicalSigns
						{
							ID=3,
								DiseaseID= 1,
							Sign="Skin lesions, including ulcers, reddening, and hemorrhages."
						},
						new ClinicalSigns
						{
							ID=4,
							DiseaseID= 1,
							Sign="Pop-eye (exophthalmia) due to eye swelling."
						},
						new ClinicalSigns
						{
							ID=5,
							DiseaseID= 1,
							Sign="Abnormal swimming behavior and respiratory distress."
						}

						#endregion 
						,
			#region Second
					
						new ClinicalSigns
						{
							ID=6,
							DiseaseID=2,
							Sign="Fish usually develop red spots or small to large ulcerative lesions on the body. The early signs of the disease include loss of appetite and fish become darker. Infected fish may float near the surface of the water, and become hyperactive with a very jerky pattern of movement"
						}

					
						#endregion
						,
			#region third

						new ClinicalSigns
						{
							ID=7,
							DiseaseID = 3,
							Sign="White or grayish patches resembling cotton wool on the skin, fins, and gills."
						},
						new ClinicalSigns
						{
							ID=8,
							DiseaseID = 3,
							Sign="Ulcerations and lesions on the skin, often accompanied by inflammation."
						},
						new ClinicalSigns
						{
							ID=9,
							DiseaseID = 3,
							Sign="Loss of scales and fin rot."
						},
						new ClinicalSigns
						{
							ID=10,
							DiseaseID = 3,
							Sign="Respiratory distress, including rapid gill movement or gasping at the water surface."
						},
						new ClinicalSigns
						{
							ID=11,
							DiseaseID = 3,
							Sign="Behavioral changes such as lethargy and loss of appetite."
						}
					
			#endregion 
						,
			#region Forth
					
						new ClinicalSigns
						{
							ID=12,
							DiseaseID = 4,
							Sign="Bacterial Gill Disease will attack your fish's gills, causing them to rot and erode. This will make it harder for your fish to breath, so you may see it gasping for air at the water surface or rapid gill movement. Unsurprisingly, your fish will also have little appetite and may be losing weight"
						}
			#endregion
				);
		}
	}
	public class DiagnosisSeeds : IEntityTypeConfiguration<Diagnosis>
	{
		public void Configure(EntityTypeBuilder<Diagnosis> builder)
		{
			builder.HasData(
			#region First
					
						new Diagnosis
						{
							ID=1,
							DiseaseID = 1,
							Diagones="Clinical Observation: Identify clinical signs such as lethargy, loss of appetite, skin lesions, pop-eye, and respiratory distress in affected tilapia."
						},
						new Diagnosis
						{
							ID=2,
							DiseaseID= 1,
							Diagones="Sample Collection: Collect tissue samples (e.g., liver, spleen) from affected fish for laboratory analysis."
						},
						new Diagnosis
						{
							ID=3,
							DiseaseID= 1,
							Diagones="Bacterial Isolation: Isolate Streptococcus bacteria from the tissue samples using appropriate culture techniques."
						},
						new Diagnosis
						{
								ID=4,
							DiseaseID= 1,
							Diagones="Confirmation: Confirm the presence of Streptococcus iniae or other relevant species through bacterial identification tests, such as PCR or biochemical assays."
						}
					
			#endregion
						,
			#region Second

						new Diagnosis
						{
							ID=5,
							DiseaseID = 2,
							Diagones="Clinical Examination: Fish displaying symptoms such as ulcerative lesions on the skin and fins are examined closely for characteristic signs of EUS."
						},
						new Diagnosis
						{
							ID=6,
							DiseaseID = 2,
							Diagones="Microscopic Analysis: Samples of affected tissue, such as skin or fin lesions, are collected and examined under a microscope to identify the presence of Aphanomyces invadans, the fungus responsible for EUS.\r\n"
						},
						new Diagnosis
						{
							ID=7,
							DiseaseID = 2,
							Diagones="Culture and Molecular Techniques: The fungus can be cultured from tissue samples to confirm its presence and identify its characteristics. Molecular techniques such as PCR (polymerase chain reaction) may also be employed for more rapid and specific detection of Aphanomyces invadans DNA."
						},
						new Diagnosis
						{
							ID=8,
							DiseaseID = 2,
							Diagones="Histopathology: Histopathological examination of tissue samples can provide additional insights into the extent of tissue damage and the inflammatory response associated with EUS."
						}
					
			#endregion 
						,
			#region Third

						new Diagnosis
						{
							ID=9,
							DiseaseID = 3,
							Diagones="Clinical Examination: Identify clinical signs such as white or grayish patches resembling cotton wool on the skin, fins, and gills, as well as ulcerations and lesions."
						},
						new Diagnosis
						{
							ID=10,
							DiseaseID = 3,
							Diagones="Microscopic Examination: Examine skin and gill smears under a microscope for characteristic bacterial colonies and signs of infection."
						},
						new Diagnosis
						{
							ID=11,
							DiseaseID = 3,
							Diagones="Bacterial Culture: Perform bacterial culture to isolate and identify Flavobacterium columnare."
						},
						new Diagnosis
						{
							ID=12,
							DiseaseID = 3,
							Diagones="Confirmation: Confirm the diagnosis based on clinical signs, microscopic examination, and bacterial culture results."
						}
					
			#endregion 
						,
			#region Forth
				
						new Diagnosis
						{
							ID=13,
							DiseaseID = 4,
							Diagones="Diagnosis of bacterial gill disease depends on the detection of large numbers of filamentous bacteria on the gills. Along with the clinical signs described above, this observation represents diagnostic evidence of the disease. there are several forms for diagnosing Bacterial gill disease:"
						},
						new Diagnosis
						{
							ID=14,
							DiseaseID = 4,
							Diagones="Microscopic Examination: To diagnose gill disease, a microscopic examination of the affected gill tissue is typically performed. The presence of fungal hyphae, spores, or other characteristic structures can confirm the infection. The examination may involve taking a small sample of the gill tissue and staining it for microscopic observation."
						},
						new Diagnosis
						{
							ID=15,
							DiseaseID = 4,
							Diagones="Laboratory Culture: In some cases, the pathogenic fungus may need to be cultured in a laboratory setting to confirm the diagnosis. This involves growing the fungus from a sample taken from the affected gills on specific culture media. The growth characteristics and appearance of the cultured fungus can help identify the causative organism."
						},
						new Diagnosis
						{
							ID=16,
							DiseaseID = 4,
							Diagones="Differential Diagnosis: Other diseases or conditions can cause similar symptoms to gill disease, so it is essential to consider differential diagnoses. These can include other fungal infections, bacterial infections, parasitic infestations, and environmental factors like poor water quality."
						},
						new Diagnosis
						{
							ID=17,
							DiseaseID = 4,
							Diagones="Veterinary Consultation: If gill disease is suspected, it is advisable to consult a veterinarian or fish health professional with experience in aquatic diseases. They can perform the necessary diagnostic tests, provide treatment recommendations, and offer guidance on disease prevention and management."
						},
						new Diagnosis
						{
							ID=18,
							DiseaseID = 4,
							Diagones="Early diagnosis and prompt treatment are crucial in managing gill disease. Treatment typically involves antifungal medications, which may be administered orally, through the water, or by injection, depending on the severity of the infection. Additionally, addressing any underlying environmental issues, such as poor water quality or stressors, is essential to prevent disease recurrence."
						}
					
			#endregion
				);
		}
	}
	public class TreatmentSeeds : IEntityTypeConfiguration<Treatment>
	{
		public void Configure(EntityTypeBuilder<Treatment> builder)
		{
			builder.HasData(
			#region First
				
						new Treatment
						{
							ID=1,
							DiseaseID=1,
							TreatmentDesc="Antibiotic Therapy: Administer antibiotics effective against Streptococcus bacteria, such as florfenicol or oxytetracycline, following veterinary guidance."
						},
						new Treatment
						{
							ID=2,
							DiseaseID= 1,
							TreatmentDesc="Supportive Care: Provide supportive care, including maintaining optimal water quality, nutrition, and minimizing stressors to enhance fish immune function."
						},
						new Treatment
						{
							ID=3,
							DiseaseID= 1,
							TreatmentDesc="Topical Treatments: Employ topical treatments or baths with antimicrobial agents to target localized infections, especially for skin lesions."
						},
						new Treatment
						{
								ID=4,
							DiseaseID= 1,
							TreatmentDesc="Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population."
						},
						new Treatment
						{
							ID=5,
							DiseaseID= 1,
							TreatmentDesc="Monitoring: Monitor the progress of treatment closely and adjust treatment protocols as necessary based on the response of the infected fish"
						}
			#endregion
				,
			#region second

						new Treatment
						{
							ID=6,
							DiseaseID = 2,
							TreatmentDesc="Quarantine and Biosecurity: Infected fish should be isolated to prevent the spread of the disease to healthy populations. Implementing strict biosecurity measures in aquaculture facilities can help prevent the introduction and transmission of EUS."
						},
						new Treatment
						{
							ID=7,
							DiseaseID = 2,
							TreatmentDesc="Water Quality Management: Maintaining optimal water quality parameters such as temperature, pH, dissolved oxygen levels, and ammonia concentration can help reduce stress on fish and enhance their immune response to the disease."
						},
						new Treatment
						{
							ID=8,
							DiseaseID = 2,
							TreatmentDesc="Antimicrobial Treatment: In cases of severe infection, antimicrobial agents may be used to control secondary bacterial infections and prevent further tissue damage. However, the use of antibiotics should be carefully regulated to prevent the development of antimicrobial resistance."
						},
						new Treatment
						{
							ID=9,
							DiseaseID = 2,
							TreatmentDesc="Topical Treatments: Topical treatments such as antiseptic solutions or medicated baths may be applied directly to the ulcerated lesions to promote healing and prevent secondary infections."
						},
						new Treatment
						{
							ID=10,
							DiseaseID = 2,
							TreatmentDesc="Supportive Care: Providing appropriate nutrition and minimizing stress through proper husbandry practices can help boost the immune system of infected fish and improve their overall health."
						},
						new Treatment
						{
							ID=11,
							DiseaseID = 2,
							TreatmentDesc="Environmental Management: Implementing environmental modifications such as reducing stocking density, improving water circulation, and removing organic debris can create less favorable conditions for the pathogen responsible for EUS."
						},
						new Treatment
						{
							ID=12,
							DiseaseID = 2,
							TreatmentDesc="Vaccination: Research into the development of vaccines against EUS-causing pathogens is ongoing. Vaccination of susceptible fish populations may offer long-term protection against the disease."
						}
					
			#endregion
				,
			#region third

						new Treatment
						{
							ID=13,
							DiseaseID = 3,
							TreatmentDesc="Antibiotic Therapy: Administer antibiotics effective against Streptococcus bacteria, such as florfenicol or oxytetracycline, following veterinary guidance."
						},
						new Treatment
						{
							ID=14,
							DiseaseID = 3,
							TreatmentDesc="Supportive Care: Provide supportive care, including maintaining optimal water quality, nutrition, and minimizing stressors to enhance fish immune function."
						},
						new Treatment
						{
							ID=15,
							DiseaseID = 3,
							TreatmentDesc="Topical Treatments: Employ topical treatments or baths with antimicrobial agents to target localized infections, especially for skin lesions."
						},
						new Treatment
						{
							ID=16,
							DiseaseID = 3,
							TreatmentDesc="Quarantine: Isolate infected fish to prevent the spread of the disease to other individuals in the population."
						},
						new Treatment
						{
							ID=17,
							DiseaseID = 3,
							TreatmentDesc="Monitoring: Monitor the progress of treatment closely and adjust treatment protocols as necessary based on the response of the infected fish"
						}
					
			#endregion
				,
			#region forth

						new Treatment
						{ 
							ID=18,
							DiseaseID = 4,
							TreatmentDesc="Bacterial gill disease must first be treated with a change in the living conditions of the fish. If they are crowded, they will need to be given more space, either in a larger aquarium, or separated into different aquariums. The cleanliness of the water and aquarium is paramount. A treatment of potassium permanganate and salt water additives can be used to help the fish heal and recover from the infection. The amount of salt you will use will depend upon the species you are treating, but it must be a salt that is specifically made for fish water, and it should only be in the prescribed amount. Antibiotic therapy may be used to treat secondary bacterial infections."
						}
					
			#endregion
			);
		}
	}
	public class ImpactOnAquacultureSeeds : IEntityTypeConfiguration<ImpactOnAquaculture>
	{
		public void Configure(EntityTypeBuilder<ImpactOnAquaculture> builder)
		{
			builder.HasData(
			#region First
				
						new ImpactOnAquaculture
						{
							ID=1,
							DiseaseID = 1,
							ImpactOnAquaculturee="Economic Losses: Streptococcosis outbreaks can lead to high mortality rates in affected fish populations, resulting in economic losses for tilapia farmers. Mortality can occur at any stage of production, from juvenile to market size, affecting both production efficiency and profitability."
						},
						new ImpactOnAquaculture
						{
							ID=2,
							DiseaseID = 1,
							ImpactOnAquaculturee="Reduced Growth Rates: Infected tilapia often exhibit reduced growth rates and poor feed conversion efficiency, leading to prolonged production cycles and decreased marketable sizes. This results in decreased productivity and increased production costs."
						},
						new ImpactOnAquaculture
						{
							ID=3,
							DiseaseID=1,
							ImpactOnAquaculturee="Treatment Costs: Treating streptococcosis infections in tilapia requires the administration of antibiotics, which adds to production costs. Additionally, repeated use of antibiotics can contribute to the development of antimicrobial resistance, posing long-term challenges for disease management in aquaculture."
						},
						new ImpactOnAquaculture
						{
							ID=4,
							DiseaseID = 1,
							ImpactOnAquaculturee="Market Access Restrictions: Streptococcosis outbreaks may lead to market access restrictions or trade bans on affected tilapia products due to concerns about food safety and public health. This can further exacerbate economic losses for tilapia farmers and impact the reputation of the aquaculture industry."
						},
						new ImpactOnAquaculture
						{
							ID=5,
							DiseaseID=1,
							ImpactOnAquaculturee="Environmental Impact: Streptococcosis outbreaks can result in increased nutrient loading and microbial contamination in aquaculture systems, potentially leading to environmental degradation and negative impacts on water quality and ecosystem health."
						}
					
				#endregion
			,
			#region Second
					
						new ImpactOnAquaculture
						{
							ID=6,
							DiseaseID = 2,
							ImpactOnAquaculturee="Economic Losses: EUS outbreaks can lead to mass mortality events, resulting in substantial financial losses for aquaculture businesses due to the death of fish stocks and reduced production."
						},
						new ImpactOnAquaculture
						{
								ID=7,
							DiseaseID = 2,
							ImpactOnAquaculturee="Production Disruption: Disease outbreaks can disrupt aquaculture production schedules, leading to delays in harvesting or stocking and affecting market supply and demand dynamics."
						},
						new ImpactOnAquaculture
						{
							ID=8,
							DiseaseID = 2,
							ImpactOnAquaculturee="Increased Costs: Controlling and managing EUS outbreaks often require additional expenses for disease treatment, water quality management, and implementing biosecurity measures, increasing overall production costs."
						},
						new ImpactOnAquaculture
						{
							ID =9,
							DiseaseID = 2,
							ImpactOnAquaculturee="Market Perception: Public perception of EUS outbreaks can negatively affect consumer confidence in the safety and quality of farmed fish products, potentially leading to decreased market demand and sales."
						},
						new ImpactOnAquaculture
						{
							ID=10,
							DiseaseID = 2,
							ImpactOnAquaculturee="Regulatory Scrutiny: EUS outbreaks may attract regulatory attention, leading to increased oversight, stricter regulations, and compliance requirements for aquaculture operations, further adding to operational challenges and costs."
						}
					
						#endregion
			,
			#region third
					
						new ImpactOnAquaculture
						{
							ID=11,
							DiseaseID = 3,
							ImpactOnAquaculturee="Economic Losses: Columnaris disease leads to economic losses in tilapia aquaculture due to morbidity, mortality, and treatment costs."
						},
						new ImpactOnAquaculture
						{
							ID=12,
							DiseaseID = 3,
							ImpactOnAquaculturee="Decreased Growth Rates: Infected tilapia exhibit reduced growth rates and poor feed conversion efficiency."
						},
						new ImpactOnAquaculture
						{
							ID=13,
							DiseaseID = 3,
							ImpactOnAquaculturee="Marketability: It can reduce the marketability of infected fish due to skin lesions, fin rot, and other clinical signs."
						},
						new ImpactOnAquaculture
						{
							ID=14,
							DiseaseID = 3,
							ImpactOnAquaculturee="Overall Health Impact: Outbreaks compromise the overall health of tilapia populations, impacting the sustainability of aquaculture operations."
						},
						new ImpactOnAquaculture
						{
							ID=15,
							DiseaseID = 3,
							ImpactOnAquaculturee="Treatment Challenges: Treatment involves antibiotics, adding to production costs and posing challenges due to antimicrobial resistance concerns."
						}
					

					#endregion
			,
			#region Forth
				
						new ImpactOnAquaculture
						{
							ID=16,
							DiseaseID = 4,
							ImpactOnAquaculturee="Economic Losses: Bacterial gill diseases can lead to high mortality rates among fish populations, resulting in economic losses for aquaculture producers due to decreased yields and potential market losses."
						},
						new ImpactOnAquaculture
						{
							ID=17,
							DiseaseID = 4,
							ImpactOnAquaculturee="Treatment Costs: Treating bacterial gill diseases often requires the use of antibiotics or other medications, which can be costly for aquaculture operations. Additionally, the labor and resources required for disease management further add to production expenses."
						},
						new ImpactOnAquaculture
						{
							ID=18,
							DiseaseID = 4,
							ImpactOnAquaculturee="Environmental Impact: The use of antibiotics and other medications in aquaculture to control bacterial gill diseases can contribute to the development of antibiotic resistance in bacteria, posing risks to human health and the environment."
						},
						new ImpactOnAquaculture
						{
							ID=19,
							DiseaseID = 4,
							ImpactOnAquaculturee="Biosecurity Risks: Bacterial gill diseases can spread rapidly within aquaculture facilities, especially in densely stocked systems. Poor biosecurity practices can further exacerbate disease transmission and impact overall farm health."
						},
						new ImpactOnAquaculture
						{
							ID=20,
							DiseaseID = 4,
							ImpactOnAquaculturee="Market Reputation: Recurrent outbreaks of bacterial gill diseases can damage the reputation of aquaculture producers and their products in the market, leading to decreased consumer confidence and potential market rejection."
						}
					

					#endregion
			);
		}
	}
}
