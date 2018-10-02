/*Archivos aleatorios con menu*/

import java.io.*;

class persona{
	public int edad;
	public String nombre;
	public float CRAEST;

	public persona(int edad, float CRAEST, String nombre){
		this.edad = edad;
		this.CRAEST = CRAEST;
		if(nombre.length() < 60){
			this.nombre = String.format("%-60s", nombre);
		}
		else{
			this.nombre = nombre.substring(0,60);
		}
	}
}

public class aleatorio{
	public static void main(String[] args) throws Exception{

		//ESCRITURA
		RandomAccessFile arch = new RandomAccessFile("D:/LP2/menuAleatorioJava/datos.dat","rw");

		persona p1 = new persona(23, 34.3f, "Miguel Gonzales");

		arch.writeUTF(p1.nombre);
		arch.writeInt(p1.edad);
		arch.writeFloat(p1.CRAEST);

		persona p2 = new persona(19, 21.0f, "Karla Cordova");

		arch.writeUTF(p2.nombre);
		arch.writeInt(p2.edad);
		arch.writeFloat(p2.CRAEST);

		arch.close();

		//LECTURA Y MODIFICACION

		RandomAccessFile archAleatorio = new RandomAccessFile("D:/LP2/menuAleatorioJava/datos.dat","rw");
		FileWriter fw = new FileWriter("D:/LP2/menuAleatorioJava/resp.txt");
		BufferedWriter bw = new BufferedWriter(fw);

		int tamanhoArch = (int)archAleatorio.length();
		int tamanhoRegistro = 70;

/*		String nombre = archAleatorio.readUTF().trim();
		int edad = archAleatorio.readInt();
		float craest = archAleatorio.readFloat();
		bw.write(nombre + " " + edad + " " + craest);
*/
		int rpta;
		do{
			System.out.println("BIENVENIDO AL SISTEMA " +
				"DE GESTION DE MEDICOS: \n");
			System.out.println("OPCIONES:");
			System.out.println("1. Listar Medicos");
			System.out.println("2. Modificar Medico");
			System.out.println("3. SALIR");
			System.out.print("Seleccione una opcion: ");
			rpta = Integer.parseInt(System.console().readLine());
			switch(rpta){
				case 1:
				archAleatorio.seek(0);
				int cant = (int)tamanhoArch/tamanhoRegistro;
				for(int j=0;j<cant;j++){
					String nombre = archAleatorio.readUTF().trim();
					int edad = archAleatorio.readInt();
					float craest = archAleatorio.readFloat();
					bw.write(nombre + " " + edad + " " + craest);
					bw.newLine();
				}
				break;
				case 2:
				System.out.println("Ingrese el registro a modificar: ");
				int reg = Integer.parseInt(System.console().readLine());
				int pos = reg * 70;
				archAleatorio.seek(pos);

				System.out.println("Ingrese la edad: ");
				int e = Integer.parseInt(System.console().readLine());
				System.out.println("Ingrese el craest: ");
				float c = Float.parseFloat(System.console().readLine());
				System.out.println("Ingrese el nombre: ");
				String n = System.console().readLine();

				persona p3 = new persona(e,c,n);

				archAleatorio.writeUTF(p3.nombre);
				archAleatorio.writeInt(p3.edad);
				archAleatorio.writeFloat(p3.CRAEST);

				break;

			}
		}while(rpta!=3);


		archAleatorio.close();
		bw.close();
		fw.close();

	}
}