package type;

public class WaitType extends Type{
    public WaitType() {
        super("wait-command");
    }

    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("point");
    }
    
}
