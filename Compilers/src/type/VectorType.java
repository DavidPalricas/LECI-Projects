package type;
public class VectorType extends Type{
    public VectorType() {
        super("vector");
    }
    
    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("coordinate");
    }
    
}
