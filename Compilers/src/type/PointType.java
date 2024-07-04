package type;
public class PointType extends Type{
    public PointType() {
        super("point");
    }
    
    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("coordinate");
    }
    
}
