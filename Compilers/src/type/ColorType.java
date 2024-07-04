package type;

public class ColorType extends Type {
    public ColorType() {
        super("color");
    }

    @Override
    public boolean subtype(Type other) {
        return super.subtype(other) || other.name().equals("string");
    }

    
}
