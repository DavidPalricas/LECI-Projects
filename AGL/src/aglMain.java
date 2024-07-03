import java.io.IOException;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.tree.*;
import org.stringtemplate.v4.*;
import error.*;
import java.io.File;
import java.io.PrintWriter;

public class aglMain {
   public static void main(String[] args) {
      try {
         // create a CharStream that reads from standard input:
         CharStream input = CharStreams.fromStream(System.in);
         // create a lexer that feeds off of input CharStream:
         aglLexer lexer = new aglLexer(input);
         // create a buffer of tokens pulled from the lexer:
         CommonTokenStream tokens = new CommonTokenStream(lexer);
         // create a parser that feeds off the tokens buffer:
         aglParser parser = new aglParser(tokens);
         // replace error listener:
         //parser.removeErrorListeners(); // remove ConsoleErrorListener
         //parser.addErrorListener(new ErrorHandlingListener());
         // begin parsing at program rule:
         ParseTree tree = parser.program();
         if (parser.getNumberOfSyntaxErrors() == 0) {
            // print LISP-style tree:
            // System.out.println(tree.toStringTree(parser));
            semantic_analysis visitor0 = new semantic_analysis();
            visitor0.visit(tree);
            
				if (!ErrorHandling.error()) {
               aglCompiler visitor1 = new aglCompiler();
               ST result = visitor1.visit(tree);

               String filename = "out.py";
					String output = result.render();
               try {
						PrintWriter pw = new PrintWriter(new File(filename));
						pw.print(output);
						pw.close();
					} catch (IOException e) {
						System.err.println("ERROR: Can't Write the File\n");
						System.exit(2);
					}
            }
            else {
               ErrorHandling.reset();
            }
         }
      }
      catch(IOException e) {
         e.printStackTrace();
         System.exit(1);
      }
      catch(RecognitionException e) {
         e.printStackTrace();
         System.exit(1);
      }
   }
}
