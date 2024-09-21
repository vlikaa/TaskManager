namespace TaskManager.Messages;

public class ChangeIntervalMessage(int interval) : IMessage
{
	public int Interval { get; } = interval;
}