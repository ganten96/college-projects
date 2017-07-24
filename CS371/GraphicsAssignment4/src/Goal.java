
import com.jogamp.opengl.util.gl2.GLUT;
import com.jogamp.opengl.util.texture.Texture;
import javax.media.opengl.GL2;
import javax.media.opengl.GLAutoDrawable;
import com.jogamp.opengl.util.texture.TextureIO;
import javax.media.opengl.glu.GLU;
import javax.media.opengl.glu.GLUquadric;
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Nick
 */
public class Goal extends GameObject
{
    //public Vector3 position;
    //public Vector3 direction;
    //public int degrees;			// Degree measure of direction 
    //public double bounding_cir_rad;	// Radius of bounding circle -- to detect collision
    //public int my_display_list;
    //the_game my_playing_field;
    //GLAutoDrawable drawable;
    Team goalTeam;
    float[] goalColor;
    Texture texture;
    public Goal(double x, double y, double z, 
                Vector3 dir, 
                double bounding_cir_rad, 
                int display_list, 
                the_game playing_field, 
                GLAutoDrawable drawable, Team t, float[] color, Texture tex) 
    {
        super(x, y, z, dir, bounding_cir_rad, display_list, playing_field, drawable);
        goalTeam = t;
        goalColor = color;
        direction = dir;
        texture = tex;
    }
    @Override
    void draw_self(GLAutoDrawable drawable) 
    {
        GLUT glut = new GLUT();
        GL2 gl = drawable.getGL().getGL2();
        gl.glPushMatrix();
        gl.glTranslated(super.position.x, 30, super.position.z);
        gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT , goalColor, 0);
        gl.glMaterialfv(GL2.GL_FRONT, GL2.GL_DIFFUSE , goalColor, 0);
        glut.glutSolidTorus(5, 25, 20, 20);
        gl.glPopMatrix();
        gl.glFlush();
    }
    
    public void scored(Team scoringTeam)
    {
        scoringTeam.score++;
    }
    
    public void win()
    {
        
    }
    
    public void respawn()
    {
        
    }
}
