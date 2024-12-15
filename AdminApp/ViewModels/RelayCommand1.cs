
public class RelayCommand
{
    private Func<Task> value;

    public RelayCommand(Func<Task> value)
    {
        this.value = value;
    }
}