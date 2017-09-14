public class FileAppender : Appender
{
    private long messageSize;

    public FileAppender(ILayout layout, ReportLevel reportLevel)
        : base(layout, reportLevel)
    {
        this.messageSize = 0;
    }

    protected override void ProcessMessage(string formattedMessage)
    {
        // TODO: Record message
        UpdateSize(formattedMessage);
    }

    // TODO: doesn't count correctly
    protected void UpdateSize(string formattedMessage)
    {
        long sum = 0L;

        for (int i = 0; i < formattedMessage.Length; i++)
        {
            char currentSymbol = formattedMessage[i];
            if (!currentSymbol.Equals('\n') && !currentSymbol.Equals('\r') && !currentSymbol.Equals(' '))
            {
                sum += currentSymbol;
            }
        }

        this.messageSize += sum;
    }

    public override string ToString()
    {
        return base.ToString() + $", File size: {this.messageSize}";
    }
}