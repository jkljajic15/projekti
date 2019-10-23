#include <stdio.h>
// Jovan Kljajic s12/15 2s3
int main()
{
    printf("Pikado, by Jovan Kljajic S12/15");
    int bodovi1, bodovi2, pogodjeno_polje;
    bodovi1=0;
    bodovi2=0;
    printf("\n_________________________________\n\nPrvi igrac ima: %d\n", bodovi1);
    printf("Drugi igrac ima: %d\n\n", bodovi2);
    printf("Prvi igrac je na potezu!\n");
    printf("Koje polje je pogodjeno? ");
    scanf("%d",&pogodjeno_polje);
    if(pogodjeno_polje < 1 || pogodjeno_polje > 20)
    {
        printf("Promasaj! Prihvatamo samo polja od 1 do 20.\n");

    }
    else
    {
        bodovi1=bodovi1+pogodjeno_polje;
    }
    printf("\n_________________________________\n\nPrvi igrac ima: %d\n", bodovi1);
    printf("Drugi igrac ima: %d\n\n", bodovi2);
    printf("Drugi igrac je na potezu!\n");
    printf("Koje polje je pogodjeno? ");
    scanf("%d",&pogodjeno_polje);
        if(pogodjeno_polje < 1 || pogodjeno_polje > 20)
    {
        printf("Promasaj! Prihvatamo samo polja od 1 do 20.\n");
    }
    else
    {
        bodovi2=bodovi2+pogodjeno_polje;
    }
    if(bodovi2 == bodovi1)
    {
        printf("Drugi igrac obara prvog igraca! Prvi igrac sada ima 0 bodova.\n");
        bodovi1=0;
    }
    do
    {
    printf("\n_________________________________\n\nPrvi igrac ima: %d\n", bodovi1);
    printf("Drugi igrac ima: %d\n\n", bodovi2);
    printf("Prvi igrac je na potezu!\n");
    printf("Koje polje je pogodjeno? ");
    scanf("%d",&pogodjeno_polje);
    if(pogodjeno_polje < 1 || pogodjeno_polje > 20)
    {
        printf("Promasaj! Prihvatamo samo polja od 1 do 20.\n");

    }
    else
    {
        bodovi1=bodovi1+pogodjeno_polje;
        if(bodovi1 == 100)
        {
        printf("\n_________________________________\n\nPrvi igrac je pobedio!!!\n");
        return 0;
        }
    }
    if(bodovi1 > 100)
    {
        printf("Prekoracenje, bodovi se ne racunaju!\n");
        bodovi1=bodovi1-pogodjeno_polje;
    }
    if(bodovi1 == bodovi2)
    {
        printf("Prvi igrac obara drugog igraca! Drugi igrac sada ima 0 bodova.\n");
        bodovi2=0;
    }
    ///Prvi igrac je zavrsio gadjanje
    printf("\n_________________________________\n\nPrvi igrac ima: %d\n", bodovi1);
    printf("Drugi igrac ima: %d\n\n", bodovi2);
    printf("Drugi igrac je na potezu!\n");
    printf("Koje polje je pogodjeno? ");
    scanf("%d",&pogodjeno_polje);
        if(pogodjeno_polje < 1 || pogodjeno_polje > 20)
    {
        printf("Promasaj! Prihvatamo samo polja od 1 do 20.\n");
    }
    else
    {
        bodovi2=bodovi2+pogodjeno_polje;
        if(bodovi2 == 100)
        {
        printf("\n_________________________________\n\n5Drugi igrac je pobedio!!!\n");
        return 0;
        }
    }
    if(bodovi2 > 100)
    {
        printf("Prekoracenje, bodovi se ne racunaju!\n");
        bodovi2=bodovi2-pogodjeno_polje;
    }
    if(bodovi2 == bodovi1)
    {
        printf("Drugi igrac obara prvog igraca! Prvi igrac sada ima 0 bodova.\n");
        bodovi1=0;
    }
    ///Drugi igrac je zavrsio gadjanje
    }
    while(bodovi1 < 100 || bodovi2 < 100);
}
