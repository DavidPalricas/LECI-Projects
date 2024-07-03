package type;
public class HexcodeType  extends Type{
    public HexcodeType() {
        super("hexcode");
    }
    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("string");
    }
    
}
