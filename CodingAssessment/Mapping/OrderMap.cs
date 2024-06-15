using System.Globalization;
using CodingAssessment.Models;
using CsvHelper.Configuration;

namespace CodingAssessment.Mapping;

public sealed class OrderMap : ClassMap<Order>
{
    public OrderMap()
    {
        Map(m => m.Id).Name("order_id");
        Map(m => m.Date).Name("date").Convert(row =>
        {
            var date = row.Row.GetField("date");
            var parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToUniversalTime();
            return parsedDate;
        });
        Map(m => m.Time).Name("time").Convert(row =>
        {
            var time = row.Row.GetField("time");
            var parsedTime = TimeSpan.Parse(time);
            return parsedTime;
        });
    }
}