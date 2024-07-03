package symbol;
import type.*;

public class VariableSymbol<T> extends Symbol<T>
{
   public VariableSymbol(String name, Type type) {
      super(name, type);
   }
}

