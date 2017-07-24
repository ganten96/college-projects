import java.awt.*;
import java.awt.event.*; 
import com.jogamp.opengl.util.FPSAnimator;
import javax.media.opengl.*;
import javax.media.opengl.glu.*;
import javax.media.opengl.awt.GLJPanel;
import javax.swing.*;
import com.jogamp.opengl.util.gl2.GLUT;
import com.jogamp.opengl.util.texture.*;
import java.io.IOException;
import java.util.Random;

// We're currently seeking Phong's Volkswagen

public class ThingWeAreSeeking extends GameObject {

    int timer = 0;
    off_file_object off_obj;
    float obj_material [] = { 0.8f, 0.0f, 0.0f, 1.0f };  // Red
    float  specref[] =  { 0.5f, 0.5f, 0.5f, 1.0f };    // material specular reflectance
    int specexp = 128;   // Initalize to maximum falloff factor
    Texture texture = null;
    GameObject carrier = null;

    ThingWeAreSeeking  (double x, double y, double z,
                Vector3 direction, 
		double bounding_cir_rad,
		int display_list,
		the_game playing_field,
		GLAutoDrawable drawable)
    {
	super (x, y, z, direction, bounding_cir_rad, display_list, playing_field, drawable);
             
        this.name = "thing";   
        
        // Load the texture
        try {
	    texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("metal-texture-17897.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }
                
    }
    
    void respawn(){
        Random rand = new Random();
        position.x = (rand.nextInt(900) + 50);
        position.z = -my_playing_field.ARENASIZE / 2.0;
        carrier = null;
        bounding_cir_rad = 10;
    }

    void draw_self (GLAutoDrawable drawable) {
        timer++;
        if(carrier != null){
            //System.out.println(carrier + " " + timer);
            this.position = new Vector3(carrier.position.x, carrier.position.y, carrier.position.z);
        }
                
	GL2 gl = drawable.getGL().getGL2();

        gl.glEnable(GL2.GL_TEXTURE_2D);
                     
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_S, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_T, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexEnvf(GL2.GL_TEXTURE_ENV, GL2.GL_TEXTURE_ENV_MODE, GL2.GL_DECAL);
        
	GLU glu = my_playing_field.glu;
	GLUquadric sphere = glu.gluNewQuadric();

	gl.glPushMatrix();
	gl.glTranslated(position.x, 7.0, position.z );
	//gl.glRotated(-90.0,  1.0,0.0,0.0);
        gl.glScaled(1.25, 1.25, 1.25);
        
        glu.gluQuadricNormals(sphere, GL2.GL_SMOOTH);
        glu.gluQuadricTexture(sphere, true);
        texture.enable(gl);
        texture.bind(gl);
        
        glu.gluSphere(sphere, bounding_cir_rad, 15, 15);
        
        texture.disable(gl);
        
	gl.glPopMatrix();
        
        gl.glDisable(GL2.GL_TEXTURE_2D);
        
    }

}