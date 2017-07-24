import java.awt.*;
import java.awt.event.*; 
import com.jogamp.opengl.util.FPSAnimator;
import javax.media.opengl.*;
import javax.media.opengl.glu.*;
import javax.media.opengl.awt.GLJPanel;
import javax.swing.*;
import com.jogamp.opengl.util.gl2.GLUT;
import com.jogamp.opengl.util.texture.Texture;
import com.jogamp.opengl.util.texture.TextureIO;
import java.io.IOException;
import java.util.Random;

public class Hero extends GameObject {

    LaserTurret main_cannon;
    int stun_timer = 0;
    int stun_duration = 200;
    int timer = 0;
    int respawn_time = 0;
    off_file_object off_obj;
    float obj_material [] = { 0.8f, 0.0f, 0.0f, 1.0f };  // Red
    float  specref[] =  { 0.5f, 0.5f, 0.5f, 1.0f };    // material specular reflectance
    int specexp = 128;   // Initalize to maximum falloff factor
    Texture texture = null;
    
    Hero (double x, double y, double z,
                Vector3 direction, 
                double bounding_cir_rad,
                int display_list,
                the_game playing_field,
                GLAutoDrawable drawable)

    {
        super (x, y, z, direction, bounding_cir_rad, display_list, playing_field, drawable);

        this.name = "hero";
        this.main_cannon = new LaserTurret(this);
        main_cannon.color = new float[]{ 0.0f,0.0f,1.0f, 1.0f };
        
        GL2 gl = drawable.getGL().getGL2();
        
	off_obj = new off_file_object("space_station.off",false); // This off file specifies vertices in CW
	off_obj.load_off_file();
        
        // Load the texture
        try {
	    texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("bluemetal.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }

	gl.glNewList(my_display_list, GL2.GL_COMPILE);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT , my_playing_field.yellow, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_DIFFUSE , my_playing_field.yellow, 0);
        gl.glTexEnvf(GL2.GL_TEXTURE_ENV, GL2.GL_TEXTURE_ENV_MODE, GL2.GL_DECAL);
        
	gl.glPushMatrix();
      
        for (int i = 0; i < off_obj.num_faces; i++) // For each face
        {
            //gl.glColor3f (0.0f, 0.0f, 1.0f);
            gl.glBegin (GL2.GL_POLYGON);
                for (int j = 0; j < off_obj.num_verts_in_face[i]; j++) // Go through verts in that face
                {
                    int n = off_obj.verts_in_face[i][j];
                    float[] texture_coords = off_obj.spherical_map(n);
                    
                    gl.glTexCoord2d(texture_coords[0], texture_coords[1]);
                    gl.glNormal3fv(off_obj.normal_to_face[i],0); // Normals same for all verts in face
                    gl.glVertex3d (off_obj.vertices[n][0],
                                   off_obj.vertices[n][1],
                                   off_obj.vertices[n][2]);
                }
            gl.glEnd ();
        }
        
	gl.glPopMatrix();
	gl.glEndList();
    }

    void draw_self (GLAutoDrawable drawable) {
        if(stun_timer == stun_duration){
            stun_timer = 0;
            can_hold_thingy = true;
        } else if(can_hold_thingy == false) {
            stun_timer++;
        }
        
        if(health <= 0){
            respawn();
        }
        
        GL2 gl = drawable.getGL().getGL2();

        texture.enable(gl);
        texture.bind(gl);
        
        gl.glPushMatrix();
        gl.glTranslated(position.x, 10.0, position.z );
        gl.glRotated(Math.signum(direction.x) * (Math.acos(direction.z) * 180) / Math.PI,  0.0,1.0,0.0);
        //gl.glScaled(0.1, 0.1, 0.1);
        gl.glRotated(-90.0,  0.0,1.0,0.0);
        gl.glRotated(-90.0,  1.0,0.0,0.0);
        gl.glCallList(my_display_list);
        gl.glPopMatrix();
        
        texture.disable(gl);
    }
    
    void respawn(){
        Random rand = new Random();
        position.x = (rand.nextInt(900) + 50);
        position.z = my_playing_field.playerOneGoal.position.z;
        health = 100;
    }
    
    @Override
    public boolean Collide(GameObject obj){
        boolean has_collided = false;
        double bounding_size = this.bounding_cir_rad > obj.bounding_cir_rad ? this.bounding_cir_rad : obj.bounding_cir_rad;
        
        if(Distance(obj) < bounding_size){
            if(obj.name == "thing" && my_playing_field.the_thing.carrier == null && this.can_hold_thingy){
                ThingWeAreSeeking thingy = (ThingWeAreSeeking)obj;
                thingy.carrier = this;
                thingy.bounding_cir_rad = this.bounding_cir_rad + 1.5;
            } else if (obj.name == "villain"){
                obj.position = obj.position.AddVec3(direction.ScalarMult(bounding_cir_rad * 5));
            } else if (obj.name == "tree"){
                this.position = this.position.SubVec3(direction.ScalarMult(2.0));
            }
            has_collided = true;
        }
        
        return has_collided;
    }

}