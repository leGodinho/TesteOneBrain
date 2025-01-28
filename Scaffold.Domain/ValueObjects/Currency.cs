using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffold.Domain.ValueObjects;

[ComplexType]
public record Currency(string Name, string Code);