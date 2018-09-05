using System;
using System.Collections.Generic;
public class Principal{
	public static void Main(){
		//Creamos el salon de clase
		Salon s1 = new Salon(123);
		//Creamos un alumno
		Alumno a1 = new Alumno("Manuel Delgado", 22);
		Alumno a2 = new Alumno("Freddy Paz", 33);
		Alumno a3 = new Alumno("Interbank", 103);
		//Creamos los cursos
		Curso c1 = new Curso("LP1", "INF263", 4.5);
		Curso c2 = new Curso("LP2", "INF321", 3.5);
		Curso c3 = new Curso("Funda", "INF666", 5);
		//Añadimos los cursos a los alumnos
		a1.agregarCurso(c1);
		a1.agregarCurso(c3);
		a2.agregarCurso(c2);
		a3.agregarCurso(c1);
		a3.agregarCurso(c2);
		a3.agregarCurso(c3);
		//Agregamos los alumnos al salon
		s1.agregarAlumno(a1);
		s1.agregarAlumno(a2);
		s1.agregarAlumno(a3);
		//Imprimimos los cursos
		string reporte2 = s1.mostrarCursos();
		Console.WriteLine(reporte2);

		//Imprimimos los alumnos de la clase
		string reporte = s1.mostrarAlumnos();
		Console.WriteLine(reporte);

	}
}

class Salon{
	private int numeroAula;
	private List<Alumno> alumnos;

	public Salon(){
		alumnos = new List<Alumno>();
	}

	public Salon(int numeroAula){
		this.numeroAula = numeroAula;
		alumnos = new List<Alumno>();
	}

	public int getNumeroAula(){
		return numeroAula;
	}

	public void setNumeroAula(int numeroAula){
		this.numeroAula = numeroAula;
	}

	public void agregarAlumno(Alumno a){
		alumnos.Add(a);
	}

	public string mostrarAlumnos(){
		string cadena = "";
		foreach(Alumno a in alumnos){
			cadena += a.consultarDatos();
		}
		return cadena;
	}

	public string mostrarCursos(){
		int ind = 1;
		string cadena = "";
		foreach(Alumno a in alumnos){
			cadena += "Alumno " + ind++ + ": \n";
			foreach(Curso c in a.getCursos()){
				cadena += c.consultarDatos();		
			}
		}
		return cadena;
	}
}

class Alumno{
	private string nombre;
	private int edad;
	private List<Curso> cursos;


	public Alumno(string nombre, int edad){
		this.nombre = nombre;
		this.edad = edad;
		cursos = new List<Curso>();
	}

	public string getNombre(){
		return nombre;
	}

	public void setNombre(string nombre){
		this.nombre = nombre;
	}

	public int getEdad(){
		return edad;
	}

	public void setEdad(int edad){
		this.edad = edad;
	}

	public string consultarDatos(){
		return "Alumno: " + nombre + " " + "Edad: " + edad + "\n";
	}

	public void agregarCurso(Curso c){
		cursos.Add(c);
	}

	public List<Curso> getCursos(){
		return cursos;
	}
}

class Curso{
	private string nomCur;
	private string codCur;
	private double credCur;

	public Curso(string nomCur, string codCur, double credCur){
		this.nomCur = nomCur;
		this.codCur = codCur;
		this.credCur = credCur;
	}

	public string getNomCur(){
		return nomCur;
	}

	public void setNumCur(string nomCur){
		this.nomCur = nomCur;
	}

	public string getCodCur(){
		return codCur;
	}

	public void setCodCur(string codCur){
		this.codCur = codCur;
	}

	public double getCredCur(){
		return credCur;
	}

	public void setCredCur(float credCur){
		this.credCur = credCur;
	}

	public string consultarDatos(){
		return "Curso: " + nomCur + " " + "Cod: " + codCur + 
		" " + "Creditos: " +  credCur + "\n";
	}
}