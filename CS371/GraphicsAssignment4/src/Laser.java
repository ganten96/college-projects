
import javax.media.opengl.GL2;
import javax.media.opengl.GLAutoDrawable;
import javax.media.opengl.glu.GLU;
import javax.media.opengl.glu.GLUquadric;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Matthew Zahm
 */
public class Laser extends Shot {
    
    double length;
    float[] color;
    
    Laser (double x, double y, double z,
                Vector3 direction, 
		double bounding_cir_rad,
		int display_list,
		the_game playing_field,
		GLAutoDrawable drawable,
                double speed, 
                double damage,
                double length,
                float[] color)
    {
	super (x, y, z, direction, bounding_cir_rad, display_list, playing_field, drawable, speed, damage);
        
        this.color = color;
        
        GL2 gl = drawable.getGL().getGL2();
	GLU glu = my_playing_field.glu;
	//GLUquadric cyl = glu.gluNewQuadric();
	GLUquadric sphere = glu.gluNewQuadric();
                
	gl.glNewList(my_display_list, GL2.GL_COMPILE);
	glu.gluQuadricDrawStyle(sphere, GLU.GLU_FILL); // smooth shaded 
	glu.gluQuadricNormals(sphere, GLU.GLU_SMOOTH);
	gl.glPushMatrix();
        
        glu.gluSphere(sphere, bounding_cir_rad, 15, 15);
	//glu.gluCylinder(cyl, bounding_cir_rad, bounding_cir_rad, length, 15, 5);
	gl.glPopMatrix();
  
	//gl.glPushMatrix();

	//gl.glTranslated(0, 25.0, 0 );
	//gl.glRotated(-90.0,  1.0,0.0,0.0);
	//glu.gluDisk(top, 0.0, bounding_cir_rad, 15, 5);

	//gl.glPopMatrix();
	gl.glEndList();
        
    }
    
    void draw_self (GLAutoDrawable drawable) {
	GL2 gl = drawable.getGL().getGL2();

	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT , color, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_DIFFUSE , color, 0);
        
	gl.glPushMatrix();
	gl.glTranslated(position.x + direction.x * 25.0, 10, position.z + direction.z * 25.0);
	gl.glCallList(4);
	gl.glPopMatrix();
        
    }    
}
