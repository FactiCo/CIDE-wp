using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CIDE_CotiApp
{
    public partial class CatDesc : PhoneApplicationPage
    {
        public CatDesc()
        {
            InitializeComponent();
        }

        string parameterTipo;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("tipo", out parameterTipo))
            {
                decideJusticia(parameterTipo);
            }
        }

        string paramType;

        private void decideJusticia(string tipo)
        {
            paramType = tipo;
            switch (tipo)
            {
                case "trabajo":

                    txtName.Text = "Justicia en el trabajo";
                    txtDescripcion.Text = @"El taller, la fábrica, la oficina y otros centros de trabajo son campos propicios para que afloren problemas, conflictos y controversias.

Quienes participan en el mundo laboral: el trabajador y el empleado, el patrón y el empleador, al igual que el administrador o gerente tienen intereses encontrados y a menudo opuestos. En el proceso productivo desempeñan papeles bien delimitados en el que unos supervisan, exigen y controlan el trabajo de otros para lograr las metas y objetivos que permitirán competir, vender, ganar y expandir mercados. A menudo la comunicación entre quienes participan en el proceso no es clara, frecuente ni oportuna y esto ya genera conflictos por no compartirse objetivos.

Las unidades económicas requiren mecanismos ágiles, sencillos, poco costosos, pero sobre todo efectivos que canalicen y resuelvan con prontitud, certeza y transparencia las controversias que se dan en la fábrica, el taller, la oficina y cualquier centro de trabajo. 

Algunos de los temas a ser discutidos en el marco de los foros sobre Justicia Cotidiana en material laboral son:

Seguimiento de la reforma laboral
Conflictos obrero patronales
Unificación de criterios";
                   
                    break;
                case "familia":
                    
                    txtName.Text = "Justicia para familias";
                    txtDescripcion.Text = "Justicia para familias busca encontrar formulas sencillas para mantener el equilibrio y la cohesión familiar. " + System.Environment.NewLine +
"En este tema se pretende determinar en qué casos: " + System.Environment.NewLine +
"Se puede simplificar la legislación " + System.Environment.NewLine +
"Se pueden utilizar sistemas alternativos de solución de conflictos" + System.Environment.NewLine +
"Se requiere rediseñar políticas públicas" + System.Environment.NewLine +
"Temas relacionados:" + System.Environment.NewLine +
"Divorcio: Después del DF, al menos 8 entidades tienen la figura del divorcio incausado o sin causales, que en los hechos ha mostrado gran utilidad práctica." + System.Environment.NewLine +
"Alimentos: Los juicios siguen siendo largos y el deudor alimentario tiene vías para evitar el cumplimiento de obligaciones." + System.Environment.NewLine +
"Sucesiones: Indispensable resolver problemas de sucesiones en familias de escasos recursos." + System.Environment.NewLine +
"Adopción: Trámites de adopción son largos y engorrosos, pero no deben ser simples ya que implica realizar estudios psicológicos y económicos que ayuden a determinar la idoneidad de la adopción. " + System.Environment.NewLine +
"Interdicción y Tutela: Requerirá una revisión profunda para dar alternativas viables a personas que en los hechos pueden ser inexistentes jurídicamente por lo complejo del nombramiento de un tutor. " + System.Environment.NewLine +
"Violencia Intrafamiliar: Es mucho lo que se puede proponer para ayudar a personas que sufren violencia y que no encuentran actualmente cauce idóneo, oportuno y eficaz de protección.";
                    break;
                case "vecinal":
                    txtName.Text = "Justicia vecinal y comunitaria";
                    txtDescripcion.Text = @"Los conflictos comunitarios y vecinales representan un área sensible y compleja del mundo social. Prácticamente en todos los espacios de convivencia, ya sean rurales o urbanos, el conflicto representa un aspecto constitutivo de la vida cotidiana.

Disputas por el espacio y el uso de suelo, problemas sobre basura y contaminación auditiva en barrios y condominios, pleitos entre automovilistas por el derecho de paso o litigios entre autoridades y vecinos son, tan sólo, una mínima lista del conjunto de interacciones sociales de carácter conflictivo que se presentan cotidianamente en la sociedad.

Se entiende por conflicto vecinal a un tipo particular de relaciones sociales que es el resultado de la convergencia espacio-temporal de intereses incompatibles [razones del conflicto] entre dos o más actores [partes del conflicto] con respecto a los usos o localización de un pedazo concreto del territorio habitado [componente geográfico del conflicto]. 

El Foro de Justicia vecinal y comunitaria busca identificar cómo mejorar los mecanismos de mediación y conciliación entre vecinos, acercar la justicia a las comunidades y prevenir los delitos en espacios o territorios específicos. ";
                    break;
                case "ciudadanos":
                    txtName.Text = "Justicia para ciudadanos";
                    txtDescripcion.Text = @"Una multa o clausura injustas, una licitación alejada de la ley o el mal mantenimiento de las calles, son ejemplos de actos de autoridad que se pueden combatir ante un Tribunal Contencioso Administrativo.

Los juicios ante estos tribunales buscan solucionar los conflictos entre el Estado y los ciudadanos, a quienes se les brinda la posibilidad obtener un trato justo y asegurar una reparación adecuada de los agravios causados.

Cuando existe certeza sobre la aplicación del derecho hay confianza en el funcionamiento de las instituciones. La justicia accesible, oportuna y las resoluciones respetadas, son un claro indicador de que se vive en un Estado de derecho, ello resulta en garantía a la ciudadanía para acudir a los tribunales contenciosos administrativos y obtener remedios efectivos en contra de abusos en el ejercicio del poder.

Sin embargo, la justicia administrativa no escapa a los problemas que enfrentan otros tipos de mecanismos judiciales. Entre estos problemas se encuentran los siguientes:

Los tribunales administrativos y sus servicios son poco conocidos por los ciudadanos 

Los juicios administrativos pueden ser largos, complicados y costosos 

El acceso a estos procedimientos puede ser difícil
";
                    break;
                case "emprendedores":
                    txtName.Text = "Justicia para emprendedores";
                    txtDescripcion.Text = @"¿Cuáles son los conflictos más comunes a los que se enfrentan los emprendedores de nuestro país? ¿Se resuelven o no? ¿Cómo? ¿A qué costos? ¿Qué se podría hacer para que la resolución de conflictos propios de la actividad empresarial fuese rápida, accesible y eficaz?

Los conflictos a los que se enfrentan los empresarios son de muchos tipos y en varios ámbitos:

Es muy común que tengan que lidiar con la extorsión y la mordida por parte de las autoridades administrativas.  

En el ámbito laboral, un pleito mal llevado puede significar la quiebra del negocio. 

Tratándose de conflictos mercantiles, el cobro de deudas de montos menores es prácticamente incosteable con el sistema de justicia actual. Todo está diseñado para tener que contratar un abogado y, durante el proceso, tener que dar muchas propinas en el juzgado: al actuario, al secretario, al que saca las copias, etcétera.

El objetivo de este foro es conocer a fondo las características de los conflictos a los que se enfrentan los empresarios en México con más frecuencia y las limitaciones del sistema de justicia para resolverlos";
                    break;
                case "otros":
                    txtName.Text = "Otros temas de Justicia Cotidiana";
                    txtDescripcion.Text = @"Los abusos e injusticias suceden en numerosos ámbitos y es fundamental conocerlos, entenderlos y modificarlos. 

Desde la resolución de conflictos agrarios, la necesidad de mejorar la capacitación de jueces y defensores, hasta la protección a consumidores y a usuarios del sistema bancario son otros temas de justicia cotidiana que requieren especial atención y consulta. 

Los temas que se abordan en el Foro “Otras Justicias” son:

Protección a consumidores
Sistema bancario
Justicia agraria
";
                    break;

            }
        }
    }
}