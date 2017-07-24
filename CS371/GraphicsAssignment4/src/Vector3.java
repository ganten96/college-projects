/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Matthew Zahm
 */
public class Vector3 {
    public double x;
    public double y;
    public double z;
    
    Vector3(){
        x = y = z = 0;
    }
    
    Vector3(double x, double y, double z){
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    Vector3(double[] vec){
        this.x = vec[0];
        this.y = vec[1];
        this.z = vec[2];
    }
    
    public boolean IsZero(){
        boolean what = (x < 0.00001 && x > -0.00001) && 
                (y < 0.00001 && y > -0.00001) && 
                (z < 0.00001 && z > -0.00001) ||
                Double.isNaN(x) || Double.isNaN(y) || Double.isNaN(z);
        return what;
    }
    
    public double Magnitude(){
        return Math.sqrt(Math.pow(this.x, 2) + Math.pow(this.y, 2) + Math.pow(this.z, 2));
    }
    
    public Vector3 Normalize(){
        double normal_factor = 1.0 / this.Magnitude();
        
        return this.ScalarMult(normal_factor);
    }
    
    public Vector3 ScalarMult(double scalar){
        Vector3 resulting_vector = new Vector3(x * scalar
                                           ,y * scalar
                                           ,z * scalar);
        return resulting_vector;
    }
    
    public Vector3 AddVec3(Vector3 vec){
        Vector3 resulting_vector = new Vector3(this.x + vec.x
                                                ,this.y + vec.y
                                                ,this.z + vec.z);
        return resulting_vector;
    }
    
    public Vector3 SubVec3(Vector3 vec){
        Vector3 resulting_vector = new Vector3(this.x - vec.x
                                                ,this.y - vec.y
                                                ,this.z - vec.z);
        return resulting_vector;
    }
    
    public double DotProduct(Vector3 vec){
        return this.x * vec.x + this.y * vec.y + this.z * vec.z;
    }
    
    public Vector3 CrossProduct(Vector3 right_vec){
        Vector3 resulting_vector = new Vector3(this.y * right_vec.z - this.z * right_vec.y
                                                ,this.z * right_vec.x - this.x * right_vec.z
                                                ,this.x * right_vec.y - this.y * right_vec.x);
        return resulting_vector;
    }    
    
    public Vector3 RotateAboutY(double radians){
        Vector3 resulting_vector = new Vector3(this.x * Math.cos(radians) + this.z * Math.sin(radians)
                                                ,this.y
                                                ,-1 * this.x * Math.sin(radians) + this.z * Math.cos(radians));
        return resulting_vector;
    }
    
    public String ToString(){
        return "< " + this.x + ", " + this.y + ", " + this.z + " >";
    }
}
