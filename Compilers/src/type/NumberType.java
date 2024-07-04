package type;
public class NumberType extends Type{
    public NumberType() {
        super("number");
    }
    
    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("numeric");
    }
    
}
