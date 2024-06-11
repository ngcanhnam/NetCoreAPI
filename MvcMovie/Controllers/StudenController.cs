using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Data;
using MvcMovie.Migrations;
using System.Security.Cryptography;

namespace MvcMovie.Controllers{
    public class StudentController : Controller{
        private readonly ApplicationDbContext _context;
        
        public StudentController(ApplicationDbContext context){
            _context = context;
        }
//GET Index
        public async Task<IActionResult> Index(){
            return _context.Student != null ?
            View(await _context.Student.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.Person'  is null.");
        }
//GET Create
        public IActionResult Create(){
            return View();
        }
//POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId, StudentName, Age, Address, Email")]Student student){
            if(ModelState.IsValid){
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
//GET Edit
        public async Task<IActionResult> Edit(string id){
            if (id == null || _context.Student == null){
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if(student == null){
                return NotFound();
            }
            return View(student);
        }
//POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId, StudentName, Age, Address, Email")]Student student){
            if (id != student.StudentId){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if(!StudentExists(student.StudentId)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
            
        }
//GET Delete
         public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
//POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(string id){
            if(_context.Student==null){
                return Problem("Entity set 'ApplicationDbContext.Person'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null){
                _context.Student.Remove(student);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }  
        private bool StudentExists(string id)
        {
          return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }


    }

      
 }
    
