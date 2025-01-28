using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;

[ComplexType]
public class Document(string rawNumber) : IDocument
{
    public static IDocument FromRawNumber(string rawNumber)
    {
        var onlyNumbers = Regex.Replace(rawNumber, @"[^\d]", "");
        
        if (IsCpf(onlyNumbers))
            return new Cpf(onlyNumbers);

        if (IsCnpj(onlyNumbers))
            return new Cnpj(onlyNumbers);

        return new RawDocument(onlyNumbers);
    }

    public string RawNumber { get; protected set; } = rawNumber;

    public string Formatted()
    {
        var document = FromRawNumber(RawNumber); 
        return document.Formatted();
    }

    public string Justified()
    {
        return FromRawNumber(RawNumber).Justified();
    }

    public bool IsValid()
    {
        return FromRawNumber(RawNumber).IsValid();
    }
    
    public Document AsDocument()
    {
        return new Document(RawNumber);
    }

    public static bool IsCpf(string cpf)
    {
        var multiplier1 = new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplier2 = new [] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;

        for (var j = 0; j < 10; j++)
            if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                return false;

        var tempCpf = cpf.Substring(0, 9);
        var soma = 0;

        for (var i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

        var resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        var digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    public static bool IsCnpj(string cnpj)
    {
        var multiplier1 = new [] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplier2 = new [] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;

        var tempCnpj = cnpj.Substring(0, 12);
        var soma = 0;

        for (var i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

        int resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        var digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        return cnpj.EndsWith(digito);
    }
}