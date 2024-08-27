import "./Header.css"
import { useState } from "react";
// import {  } from '@headlessui/react'
import { ShoppingBagIcon, MagnifyingGlassCircleIcon, ShoppingCartIcon, Bars2Icon, XMarkIcon } from '@heroicons/react/24/outline'


export default function Header() {
  const [open, setOpen] = useState(false);
  return (
    <>
      <header className="bg-[#20283f] text-white 
        sticky top-0 scroll-smooth">
        <nav className="
          grid grid-cols-2 sm:grid-cols-[1fr_minmax(200px,400px)_1fr] 
          place-items-center p-5 duration-500 
          gap-4"
        >
          <a href="#" className="hover:opacity-70 transition duration-500
            row-start-1 col-start-1 w-max inline-flex sm:m-0 mr-auto "
          >
            <ShoppingBagIcon className="h-10 stroke-sky-500"/>
            <div className="inline-flex items-center ml-1">
              <div className="text-xl sm:text-2xl text-blue-100 ">
                Store 
              </div>
              <span className="text-xl sm:text-2xl text-blue-300">X</span>
            </div>
          </a>
          
          <div className="inline-flex ml-auto sm:m-0">
            <a href="#" className="row-start-1 sm:col-start-3 col-start-2 
              hover:opacity-70 duration-500"
            >
              <ShoppingCartIcon className="h-10"/>
            </a>

            <div className="sm:hidden ml-4 cursor-pointer rounded-3xl bg-blue-600" 
              onClick={() => setOpen(!open)}
            >
            {open ? 
              <XMarkIcon className="h-10"/> : 
              <Bars2Icon className="h-10"/>
            }
              
            </div>

          </div>

          <form className="
            sm:row-start-1 sm:col-start-2 sm:col-end-2 
            relative col-span-2 w-full"
          >
            <input type="text" className="
              rounded-3xl text-black text-xl 
              h-12 w-full pr-14 pl-4"
            />
            <button className="h-12 w-12
             absolute end-0 hover:opacity-80 transition"
            >
              <MagnifyingGlassCircleIcon className="stroke-slate-800"/>
            </button>
          </form>

            
          <div className={`sm:hidden flex flex-col transition-all duration-300 
            transform ${open ? 'max-h-screen opacity-100 scale-y-100' : 
            'max-h-0 opacity-0 scale-y-0 overflow-hidden'}`}
          >
            <a href="#">Home</a>
            <a href="#">Market</a>
            <a href="#">Home</a>
            <a href="#">Market</a>
          </div>
          
        </nav>
      </header>
    </>
  )
}