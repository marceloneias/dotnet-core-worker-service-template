public class ServiceConfigurations
{
    public int WorkerService1_IntervalInSeconds { get; set; }
    public int WorkerService1_IntervalInMilliseconds { get { return this.WorkerService1_IntervalInSeconds * 1000; }}
    public int WorkerService2_IntervalInSeconds { get; set; }
    public int WorkerService2_IntervalInMilliseconds { get { return this.WorkerService2_IntervalInSeconds * 1000; }}
}