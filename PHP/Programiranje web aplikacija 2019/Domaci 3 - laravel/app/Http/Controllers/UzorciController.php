<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Uzorak;
use App\Laboratorija;
use Carbon\Carbon;
use DateTimeZone;

class UzorciController extends Controller
{

    public function index()
    {
        $uzorci = Uzorak::all();
        $SortiraniUzorciPoVremenu = $uzorci->sortBy('created_at');
        $SortiraniUzorciPoNazivu = $uzorci->sortBy('Naziv');
        
        return view('uzorci.index',compact('SortiraniUzorciPoNazivu','SortiraniUzorciPoVremenu'));
    }

    public function create()
    {
        return view('uzorci.create');
    }

    public function store()
    {
        $validated = request()->validate([
            'Naziv' => ['required', 'min:3', 'max:100'],
            'VremePrikupljanja' => ['required', 'numeric','gte:1'],
            'Sirina' => ['required', 'numeric'],
            'Visina' => ['required', 'numeric'],
            'Status' => ['required']
        ]);

        Uzorak::create($validated);

        return redirect('/uzorci');
    }

    public function update(Uzorak $uzorak)
    {

        $validated = request()->validate([
            'Naziv' => ['required', 'min:3', 'max:100'],
            'VremePrikupljanja' => ['required', 'numeric','gte:1'],
            'Sirina' => ['required', 'numeric'],
            'Visina' => ['required', 'numeric'],
            'Status' => ['required']
        ]);

        $uzorak->update($validated);

        return redirect('/uzorci');
    }

    public function edit(Uzorak $uzorak)
    {
        return view('uzorci.edit',compact('uzorak'));
    }

    public function destroy(Uzorak $uzorak)
    {
        $uzorak->delete();

        return redirect('/uzorci');
        
    }

    public function analize(Uzorak $uzorak)
    {
        
        $labs = Laboratorija::all()->sortBy('last_analize');
    
        $prva = $labs->first();
        $prva->last_analize = Carbon::now();
        
        $uzorak->analiziran = 1;
        $uzorak->Laboratorija = $prva->ImeLaboratorije;
        $uzorak->Ishod = Laboratorija::analiziraj();
        
        $prva->save();
        $uzorak->save();

        return redirect('/uzorci');
    }
}
