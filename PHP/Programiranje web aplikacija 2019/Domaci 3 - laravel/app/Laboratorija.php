<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Laboratorija extends Model
{
    protected $table='laboratorije';
    protected $guarded = ['id'];

    public static function analiziraj()
    {
        $arr=array('Ima zivota','Nema zivota','Nepoznato');
        return array_random($arr);
    }

    public static function roundRobin()
    {
        $sviNaZemlji = Uzorak::where('Status','Na Zemlji')->get();
        $nisuAnalizirani = $sviNaZemlji->where('analiziran',0);
        $kolekcija = array(); //za ispis na view
        
        if ($nisuAnalizirani->count()>0)
        {
            
            $labaratorije = Laboratorija::all();
            $queue = array();
            
            foreach($labaratorije as $labaratorija)
            {
                array_push($queue,$labaratorija);
            }
            
            foreach ($nisuAnalizirani as $one)
            {
                $ishod = Laboratorija::analiziraj();
                $prva = array_first($queue);
                $string = "Laboratorija: $prva->ImeLaboratorije je analizirala uzorak: $one->Naziv. Ishod je: $ishod";
                
                $one->update(['Analiziran'=>1]);
                $one->Laboratorija = $prva->ImeLaboratorije;
                $one->Ishod = $ishod;
                $one->save();
                
                array_shift($queue);
                array_push($queue,$prva);

                
                array_push($kolekcija,$string);
            }
            
            return $kolekcija;
        }
        else
        {
            return false;
        }
        
    }
}
