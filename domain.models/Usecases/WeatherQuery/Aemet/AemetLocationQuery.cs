using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace domain.models.Usecases.WeatherQuery.Aemet
{

  public class AemetLocationQueryRes
  {
    [JsonPropertyName("origen")]
    public Origen Origen { get; set; }

    [JsonPropertyName("elaborado")]
    public DateTime Elaborado { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }

    [JsonPropertyName("provincia")]
    public string Provincia { get; set; }

    [JsonPropertyName("prediccion")]
    public Prediccion Prediccion { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("version")]
    public double Version { get; set; }
  }

  public class Origen
  {
    [JsonPropertyName("productor")]
    public string Productor { get; set; }

    [JsonPropertyName("web")]
    public string Web { get; set; }

    [JsonPropertyName("enlace")]
    public string Enlace { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    [JsonPropertyName("notaLegal")]
    public string NotaLegal { get; set; }
  }

  public class ProbPrecipitacion
  {
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }
  }

  public class CotaNieveProv
  {
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }
  }

  public class EstadoCielo
  {
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }
  }

  public class Viento
  {
    [JsonPropertyName("direccion")]
    public string Direccion { get; set; }

    [JsonPropertyName("velocidad")]
    public int Velocidad { get; set; }

    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }
  }

  public class RachaMax
  {
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }
  }

  public class Dato
  {
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("hora")]
    public int Hora { get; set; }
  }

  public class Temperatura
  {
    [JsonPropertyName("maxima")]
    public int Maxima { get; set; }

    [JsonPropertyName("minima")]
    public int Minima { get; set; }

    [JsonPropertyName("dato")]
    public List<Dato> Dato { get; set; } = new List<Dato>();
  }

  public class SensTermica
  {
    [JsonPropertyName("maxima")]
    public int Maxima { get; set; }

    [JsonPropertyName("minima")]
    public int Minima { get; set; }

    [JsonPropertyName("dato")]
    public List<Dato> Dato { get; set; } = new List<Dato>();
  }

  public class HumedadRelativa
  {
    [JsonPropertyName("maxima")]
    public int Maxima { get; set; }

    [JsonPropertyName("minima")]
    public int Minima { get; set; }

    [JsonPropertyName("dato")]
    public List<Dato> Dato { get; set; } = new List<Dato>();
  }

  public class Dia
  {
    [JsonPropertyName("probPrecipitacion")]
    public List<ProbPrecipitacion> ProbPrecipitacion { get; set; } = new List<ProbPrecipitacion>();

    [JsonPropertyName("cotaNieveProv")]
    public List<CotaNieveProv> CotaNieveProv { get; set; } = new List<CotaNieveProv>();

    [JsonPropertyName("estadoCielo")]
    public List<EstadoCielo> EstadoCielo { get; set; } = new List<EstadoCielo>();

    [JsonPropertyName("viento")]
    public List<Viento> Viento { get; set; } = new List<Viento>();

    [JsonPropertyName("rachaMax")]
    public List<RachaMax> RachaMax { get; set; } = new List<RachaMax>();

    [JsonPropertyName("temperatura")]
    public Temperatura Temperatura { get; set; }

    [JsonPropertyName("sensTermica")]
    public SensTermica SensTermica { get; set; }

    [JsonPropertyName("humedadRelativa")]
    public HumedadRelativa HumedadRelativa { get; set; }

    [JsonPropertyName("uvMax")]
    public int UvMax { get; set; }

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }
  }

  public class Prediccion
  {
    [JsonPropertyName("dia")]
    public List<Dia> Dia { get; set; } = new List<Dia>();
  }

}
