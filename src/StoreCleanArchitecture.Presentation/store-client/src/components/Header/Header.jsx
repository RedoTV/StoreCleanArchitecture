import "./Header.css"
// import {  } from '@headlessui/react'
import { ShoppingBagIcon, MagnifyingGlassCircleIcon, ShoppingCartIcon } from '@heroicons/react/24/outline'


export default function Header() {

  return (
    <>
      <header className="bg-[#20283f] text-white 
        sticky top-0 scroll-smooth">
        <div className="
          grid grid-cols-2 sm:grid-cols-[1fr_minmax(400px,500px)_1fr] p-4 duration-500 
           mx-auto m-auto"
        >
          <a href="#" className="hover:opacity-70 transition duration-500 my-auto 
            row-start-1 col-start-1 w-32"
          >
            <ShoppingBagIcon className="inline-block h-8 sm:h-10"/>
            <span className="text-xl sm:text-2xl align-middle pl-2">Store</span>
          </a>

          <div className="ml-auto row-start-1 my-auto sm:col-start-3 col-start-2">
            <ShoppingCartIcon className="
              h-8 sm:h-10 cursor-pointer hover:opacity-70 
              transition duration-500 "
            />
          </div>

          <form className="sm:my-auto relative mt-4
            sm:row-start-1 sm:col-start-2 sm:col-end-2 
             row-start-2 col-start-1 col-end-3"
          >
            <input type="text" className="
              rounded-3xl pl-5 pr-14 text-black text-xl mx-auto
              w-full h-12"
            />
            <button className="h-12 w-12
             absolute end-1 hover:opacity-80 transition"
            >
              <MagnifyingGlassCircleIcon className="stroke-slate-800"/>
            </button>
          </form>
        </div>
      </header>
    </>
  )
}