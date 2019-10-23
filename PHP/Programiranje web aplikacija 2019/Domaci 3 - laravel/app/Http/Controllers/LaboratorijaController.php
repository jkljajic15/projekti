<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Laboratorija;
use App\Uzorak;

class LaboratorijaController extends Controller
{
    public function index()
    {
        
        
        $lab = Laboratorija::all();
        
        return view('laboratorije.index',compact('lab'));

    }

    public function create()
    {
        return view('laboratorije.create');
    }

    public function store()
    {
        
        
        Laboratorija::create(request()->validate(['ImeLaboratorije'=>'required|min:3|max:100']));
        
        return redirect('/lab');

    }

    public function edit(Laboratorija $lab)
    {
        return view('laboratorije.edit', compact('lab'));
    }

    public function update(Laboratorija $lab)
    {
        $lab->update(request()->validate(['ImeLaboratorije'=>'required|min:3|max:100']));
        return redirect('/lab');
    }
    
    public function destroy(Laboratorija $lab)
    {
        $lab->delete();
        return redirect('/lab');
    }

    public function analize()
    {
        $analize = Laboratorija::roundRobin();
        
        return view('analize',compact('analize'));
    }
}
