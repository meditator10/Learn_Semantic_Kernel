using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace PlanningAsyncTask.Plugins;

public class TimePlugin
{
    /// <summary>
    /// Get the current date
    /// </summary>
    /// <example>
    [KernelFunction, Description("Get the current date")]
    public string Date(IFormatProvider? formatProvider = null) =>
        DateTimeOffset.Now.ToString("D", formatProvider);

    [KernelFunction, Description("Get the current date")]
    public string Today(IFormatProvider? formatProvider = null) =>
        // Example: Sunday, 12 January, 2025
        this.Date(formatProvider);

    /// <summary>
    /// Get the current date and time in the local time zone"
    /// </summary>
    [KernelFunction, Description("Get the current date and time in the local time zone")]
    public string Now(IFormatProvider? formatProvider = null) =>
        // Sunday, January 12, 2025 9:15 PM
        DateTimeOffset.Now.ToString("f", formatProvider);

    /// <summary>
    /// Get the current UTC date and time
    /// </summary>
    [KernelFunction, Description("Get the current UTC date and time")]
    public string UtcNow(IFormatProvider? formatProvider = null) =>
        // Sunday, January 13, 2025 5:15 AM
        DateTimeOffset.UtcNow.ToString("f", formatProvider);

    /// <summary>
    /// Get the current time
    /// </summary>
    [KernelFunction, Description("Get the current time")]
    public string Time(IFormatProvider? formatProvider = null) =>
        // Example: 09:15:07 PM
        DateTimeOffset.Now.ToString("hh:mm:ss tt", formatProvider);
}