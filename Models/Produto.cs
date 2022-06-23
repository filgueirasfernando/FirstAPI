using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
  public class Produto
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Titulo { get; set; }

    [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public double Preco { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
    public int CategoriaId { get; set; }

    [SwaggerRequestBody(Required = false)]
    public Categoria Categoria { get; }
  }
}
