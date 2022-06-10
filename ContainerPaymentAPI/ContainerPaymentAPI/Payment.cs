namespace ContainerPaymentAPI
{
    public class Payment
    {
        public int Id { get; set; }
        public string containerId { get; set; }
        public float? Amount { get; set; }
    }
}
