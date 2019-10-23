#include <stdio.h>
// Jovan Kljajic s12/15
    int provera_zagrada(char tekst[])
    {
        int i;
        int brojac = 0;
        for(i=0; tekst[i] != '\0'; i++)
        {
            if( tekst[i] == '(')
            {
                brojac ++;
            }
            else if(tekst[i]==')')
            {
                brojac --;
            }

            if(brojac < 0)
            {
                break;
            }
        }

        if(brojac == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

    int main()
    {
        char linija[256];
        int brojac_linija=0, brojac_gresaka=0;
        FILE *ulazni, *izlazni;
        ulazni = fopen("ulaz.txt","rt");
        if(ulazni == NULL)
        {
            printf("Greska u otvaranju ulaznog fajla.");
            return 1;
        }
        izlazni = fopen("izlaz.txt","wt");
        if(izlazni == NULL)
        {
            printf("Greska u otvaranju izlaznog fajla.");
            return 2;
        }
        printf("Pocetak obrade...\n\n");
        while(!feof(ulazni))
        {
            fgets(linija,256,ulazni);
            brojac_linija ++;
            if(provera_zagrada(linija))
            {
                fprintf(izlazni,"%s",linija);
            }
            else
            {
                printf("Greska u %d liniji: %s\n",brojac_linija,linija);
                brojac_gresaka ++;
            }
        }
        printf("Kraj obrade, imali smo %d greska.\n\n",brojac_gresaka);
        printf("Program napisao Jovan Kljajic s12/15");
        fclose(ulazni);
        fclose(izlazni);

        return 0;
    }

















